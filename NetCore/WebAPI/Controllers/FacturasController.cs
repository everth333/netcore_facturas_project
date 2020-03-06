using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NetCore.WebAPI.Controllers.Resources;
using NetCore.Infraestructure.Commands.Facturas;
using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Queries.Facturas;
using MediatR;

namespace NetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacturasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<IEnumerable<Factura>> ListAsync()
        {
            return await _mediator.Send(new ListFacturasQuery());
        }


        // GET: api/Facturas/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Factura), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var factura = await _mediator.Send(new GetFacturaQuery(id));
            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }




        // POST: api/Facturas
        [HttpPost]
        [ProducesResponseType(typeof(Factura), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] FacturaResource resource)
        {
            var factura = await _mediator.Send(new CreateFacturaCommand(resource.IdCliente, resource.Fecha, resource.Importe, resource.Nit, resource.Razon_Social, resource.Codigo_Control, resource.Modo_Pago, resource.Codigo_Tarjeta));
            return Created($"/api/facturas/{factura.Id}", factura);
        }




        // PUT: api/Facturas/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Factura>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] FacturaResource resource)
        {
            var response = await _mediator.Send(new UpdateFacturaCommand(id, resource.IdCliente, resource.Fecha, resource.Importe, resource.Nit, resource.Razon_Social, resource.Codigo_Control, resource.Modo_Pago, resource.Codigo_Tarjeta));
            return ProduceFacturaResponse(response);
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<Factura>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteFacturaCommand(id));
            return ProduceFacturaResponse(response);
        }


        private IActionResult ProduceFacturaResponse(Response<Factura> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }


    }
}
