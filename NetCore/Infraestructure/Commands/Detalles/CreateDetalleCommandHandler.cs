using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class CreateDetalleCommandHandler : IRequestHandler<CreateDetalleCommand, Detalle>
    {
        private readonly IDetalleRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDetalleCommandHandler(IDetalleRepository detalleRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Repository = detalleRepository;
        }

        public async Task<Detalle> Handle(CreateDetalleCommand request, CancellationToken cancellationToken)
        {
            var detalle = new Detalle
            {
                IdFactura = request.IdFactura,
                IdProducto = request.IdProducto,
                Precio = request.Precio,
                Cantidad = request.Cantidad
            };

            await _Repository.AddAsync(detalle);
            await _unitOfWork.CompleteAsync();

            return detalle;
        }
    }
}
