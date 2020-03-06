using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Queries.Facturas
{
    public class ListFacturasQueryHandler : IRequestHandler<ListFacturasQuery, IEnumerable<Factura>>
    {

        private readonly IFacturaRepository _facturaRepository;

        public ListFacturasQueryHandler(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<IEnumerable<Factura>> Handle(ListFacturasQuery request, CancellationToken cancellationToken)
        {
            return await _facturaRepository.ListAsync();
        }
    }
}
