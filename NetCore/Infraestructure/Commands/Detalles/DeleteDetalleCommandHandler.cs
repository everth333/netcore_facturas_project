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
using NetCore.Infraestructure.Commands.Facturas;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class DeleteDetalleCommandHandler : IRequestHandler<DeleteDetalleCommand, Response<Detalle>>
    {
        private readonly IDetalleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetalleCommandHandler(IDetalleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Detalle>> Handle(DeleteDetalleCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.FindByIdAsync(request.Id);

            if (cliente == null)
            {
                return new Response<Detalle>("Detalle No Encontrada.");
            }

            _repository.Delete(cliente);
            await _unitOfWork.CompleteAsync();

            return new Response<Detalle>(cliente);
        }
    }
}
