using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Entities;
using NetCore.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Domain.Queries.Productos
{
    public class ListProductosQueryHandler : IRequestHandler<ListProductosQuery, IEnumerable<Producto>>
    {

        private readonly IProductoRepository _productoRepository;

        public ListProductosQueryHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> Handle(ListProductosQuery request, CancellationToken cancellationToken)
        {
            return await _productoRepository.ListAsync();
        }
    }
}
