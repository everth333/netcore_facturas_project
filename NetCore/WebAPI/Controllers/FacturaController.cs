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
    public class FacturaController: ControllerBase
    {
        FacturaRepository _Factura;
        public FacturaController(NetCoreContext context)
        {
            _Factura = new FacturaRepository(context);
        }

        [HttpGet]
        public IEnumerable<Factura> GetAll()
        {
            return _Factura.GetLista();
        }
        [HttpGet("{id}")]
        public Factura Get(int id)
        {
            return _Factura.GetEntity(id);
        }
        [HttpPost]
        public IActionResult Post(Factura eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Factura.Guardar(eEntidad);

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
        public IActionResult Put(Factura eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Factura.Modificar(eEntidad);

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

            bool resul = _Factura.Eliminar(id);

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
