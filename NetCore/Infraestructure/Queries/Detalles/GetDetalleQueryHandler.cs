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
    public class GetDetalleQueryHandler : IRequestHandler<GetDetalleQuery, Detalle>
    {
        private readonly IDetalleRepository _detalleRepository;

        public GetDetalleQueryHandler(IDetalleRepository detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }

        public async Task<Detalle> Handle(GetDetalleQuery request, CancellationToken cancellationToken)
        {
            if (request.DetalleId <= 0)
            {
                throw new ArgumentException(nameof(request.DetalleId));
            }

            return await _detalleRepository.FindByIdAsync(request.DetalleId);
        }
    }
}
