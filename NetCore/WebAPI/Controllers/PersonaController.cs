using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Infraestructure.Persistence.Repository;
using NetCore.Infraestructure.Persistence;
using NetCore.Domain.Entities;
namespace NetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        PersonaRepository _Persona;
        public PersonaController(NetCoreContext context) {
            _Persona = new PersonaRepository(context);
        }

        [HttpGet]
        public IEnumerable<Persona> GetAll() {
            return _Persona.GetLista();
        }
        [HttpGet("{id}")]
        public Persona Get(int id) {
            return _Persona.GetEntity(id);
        }
        [HttpPost]
        public IActionResult Post(Persona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul= _Persona.Guardar(persona);

            if (resul)
            {
                return Ok();
            }
            else {
                return BadRequest("Erro al crear una nueva persona");
            }

            
        }
        [HttpPut]
        public IActionResult Put(Persona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool resul = _Persona.Modificar(persona);

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
        public IActionResult Delete(int id) {

            if (id <= 0)
                return BadRequest("Not a valid person id");

            bool resul = _Persona.Eliminar(id);

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