using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class UpdateDetalleCommandHandler : IRequestHandler<UpdateDetalleCommand, Response<Detalle>>
    {
        private readonly IDetalleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDetalleCommandHandler(IDetalleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Detalle>> Handle(UpdateDetalleCommand request, CancellationToken cancellationToken)
        {
            var detalle = await _repository.FindByIdAsync(request.Id);

            if (detalle == null)
            {
                return new Response<Detalle>("Detalle No Encontrada.");
            }


            detalle.IdFactura = request.IdFactura;
            detalle.IdProducto = request.IdProducto;
            detalle.Precio = request.Precio;
            detalle.Cantidad = request.Cantidad;


            _repository.Update(detalle);
            await _unitOfWork.CompleteAsync();

            return new Response<Detalle>(detalle);
        }
    }
}
