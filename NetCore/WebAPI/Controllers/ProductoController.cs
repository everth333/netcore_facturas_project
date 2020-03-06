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
    public class ProductoController : ControllerBase
    {
        ProductoRepository _Producto;
        public ProductoController(NetCoreContext context)
        {
            _Producto = new ProductoRepository(context);
        }

        [HttpGet]
        public IEnumerable<Producto> GetAll()
        {
            return _Producto.GetLista();
        }
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            return _Producto.GetEntity(id);
        }
        [HttpPost]
        public IActionResult Post(Producto eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Producto.Guardar(eEntidad);

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
        public IActionResult Put(Producto eEntidad)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Producto.Modificar(eEntidad);

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

            bool resul = _Producto.Eliminar(id);

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
