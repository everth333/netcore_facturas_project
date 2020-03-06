using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;
using NetCore.Entities;
using NetCore.Repositories;
using MediatR;

namespace NetCore.Domain.Queries.Productos
{
    public class GetProductoQueryHandler : IRequestHandler<GetProductoQuery, Producto>
    {
        private readonly IProductoRepository _productoRepository;

        public GetProductoQueryHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<Producto> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            if (request.ProductoId <= 0)
            {
                throw new ArgumentException(nameof(request.ProductoId));
            }

            return await _productoRepository.FindByIdAsync(request.ProductoId);
        }
    }
}
