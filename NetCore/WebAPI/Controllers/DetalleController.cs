using Microsoft.AspNetCore.Mvc;
using NetCore.Infraestructure.Persistence;
using NetCore.Infraestructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;

namespace NetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController: ControllerBase
    {
        DetalleRepository _Detalle;
        public DetalleController(NetCoreContext context)
        {
            _Detalle = new DetalleRepository(context);
        }

        [HttpGet]
        public IEnumerable<Detalle> GetAll()
        {
            return _Detalle.GetLista();
        }
        [HttpGet("{id}")]
        public Detalle Get(int id)
        {
            return _Detalle.GetEntity(id);
        }
        [HttpPost]
        public IActionResult Post(Detalle eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Detalle.Guardar(eEntidad);

            if (resul)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro al crear una nueva persona");
            }


        }
        [HttpPut]
        public IActionResult Put(Detalle eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Detalle.Modificar(eEntidad);

            if (resul)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro al modificar una persona");
            }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (id <= 0)
                return BadRequest("Not a valid person id");

            bool resul = _Detalle.Eliminar(id);

            if (resul)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro al eliminar una persona");
            }

        }
    }
}
