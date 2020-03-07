using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NetCore.WebAPI.Controllers.Resources;
using NetCore.Infraestructure.Commands.Detalles;
using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Queries.Detalles;
using MediatR;

namespace NetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DetallesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Detalles
        [HttpGet]
        public async Task<IEnumerable<Detalle>> ListAsync()
        {
            return await _mediator.Send(new ListDetallesQuery());
        }


        // GET: api/Detalles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Detalle), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var detalle = await _mediator.Send(new GetDetalleQuery(id));
            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }




        // POST: api/Detalles
        [HttpPost]
        [ProducesResponseType(typeof(Detalle), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] DetalleResource resource)
        {
            var detalle = await _mediator.Send(new CreateDetalleCommand(resource.IdFactura,resource.IdProducto,resource.Precio,resource.Cantidad));
            return Created($"/api/detalles/{detalle.Id}", detalle);
        }




        // PUT: api/Detalles/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Detalle>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DetalleResource resource)
        {
            var response = await _mediator.Send(new UpdateDetalleCommand(id, resource.IdFactura, resource.IdProducto,resource.Precio,resource.Cantidad));
            return ProduceResponse(response);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<Factura>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteDetalleCommand(id));
            return ProduceResponse(response);
        }


        private IActionResult ProduceResponse(Response<Detalle> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }


    }
}
