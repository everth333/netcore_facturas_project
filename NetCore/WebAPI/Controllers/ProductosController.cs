using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NetCore.WebAPI.Controllers.Resources;
using NetCore.Infraestructure.Commands.Productos;
using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Queries.Productos;
using MediatR;

namespace NetCore.WebAPI.Controllers
{
    //[Route("api/[productos]")]//cod origin
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Lists all products from the API.
        /// </summary>
        /// <returns>List of products</returns>
        // GET: api/Productos
        [HttpGet]
        public async Task< IEnumerable<Producto>> ListAsync()
        {
            return await _mediator.Send(new ListProductosQuery());
        }


        /// <summary>
        /// Lists a given product by their ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product</returns>
        // GET: api/Productos/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Producto), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var producto = await _mediator.Send(new GetProductoQuery(id));
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }


        /// <summary>
        /// Creates a new product in the API.
        /// </summary>
        /// <param name="resource">Updated product data.</param>
        /// /// <returns>Response for the request.</returns>
        /// <response code="201">Returns the newly created product data.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        // POST: api/Productos
        [HttpPost]
        [ProducesResponseType(typeof(Producto), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] ProductoResource resource)
        {
            var producto = await _mediator.Send(new CreateProductoCommand(resource.Nombre, resource.Costo, resource.Precio, resource.Stock));
            return Created($"/api/productos/{producto.Id}", producto);
        }


        /// <summary>
        /// Updates a given product by their identifier.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="resource">Updated product data.</param>
        /// <returns>Response for the request.</returns>
        /// <response code="200">Returns the response data container the updated product information.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        // PUT: api/Productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Producto>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductoResource resource)
        {
            var response = await _mediator.Send(new UpdateProductoCommand(id, resource.Nombre, resource.Costo, resource.Precio, resource.Stock));
            return ProduceProductoResponse(response);
        }



        /// <summary>
        /// Deletes a given product by their identifier.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Response for the request</returns>
        /// <response code="200">Returns the response data container the deleted product information.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<Producto>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteProductoCommand(id));
            return ProduceProductoResponse(response);
        }

        private IActionResult ProduceProductoResponse(Response<Producto> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }


    }
}
