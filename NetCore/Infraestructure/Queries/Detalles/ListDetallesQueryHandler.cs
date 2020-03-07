using MediatR;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Queries.Detalles
{
    public class ListDetallesQueryHandler : IRequestHandler<ListDetallesQuery, IEnumerable<Detalle>>
    {
        private readonly IDetalleRepository _detalleRepository;

        public ListDetallesQueryHandler(IDetalleRepository detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }

        public async Task<IEnumerable<Detalle>> Handle(ListDetallesQuery request, CancellationToken cancellationToken)
        {
            return await _detalleRepository.ListAsync();
        }
    }
}
