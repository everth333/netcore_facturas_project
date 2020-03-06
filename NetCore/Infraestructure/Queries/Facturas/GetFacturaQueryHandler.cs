using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;

namespace NetCore.Infraestructure.Queries.Facturas
{
    public class GetFacturaQueryHandler : IRequestHandler<GetFacturaQuery, Factura>
    {
        private readonly IFacturaRepository _facturaRepository;

        public GetFacturaQueryHandler(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<Factura> Handle(GetFacturaQuery request, CancellationToken cancellationToken)
        {
            if (request.FacturaId <= 0)
            {
                throw new ArgumentException(nameof(request.FacturaId));
            }

            return await _facturaRepository.FindByIdAsync(request.FacturaId);
        }
    }
}
