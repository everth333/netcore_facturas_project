using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;


namespace NetCore.Infraestructure.Queries.Productos
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
