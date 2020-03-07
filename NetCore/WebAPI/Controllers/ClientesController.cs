using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using NetCore.WebAPI.Controllers.Resources;
using NetCore.Infraestructure.Commands.Clientes;
using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using MediatR;
using NetCore.Infraestructure.Queries.Clientes;

namespace NetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IEnumerable<Cliente>> ListAsync()
        {
            return await _mediator.Send(new ListClientesQuery());
        }


        // GET: api/Clientes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cliente = await _mediator.Send(new GetClienteQuery(id));
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }




        // POST: api/Clientes
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] ClienteResource resource)
        {
            var cliente = await _mediator.Send(new CreateClienteCommand(resource.Nombre,resource.Apellidos,resource.FechaNaciemiento,resource.Email,resource.Telefono,resource.Direccion,resource.DateCreated,resource.DateUpdated));
            return Created($"/api/clientes/{cliente.Id}", cliente);
        }




        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Cliente>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClienteResource resource)
        {
            var response = await _mediator.Send(new UpdateClienteCommand(id, resource.Nombre, resource.Apellidos, resource.FechaNaciemiento, resource.Email, resource.Telefono, resource.Direccion,resource.DateCreated,resource.DateUpdated));
            return ProduceResponse(response);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<Cliente>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteClienteCommand(id));
            return ProduceResponse(response);
        }


        private IActionResult ProduceResponse(Response<Cliente> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }


    }
}
