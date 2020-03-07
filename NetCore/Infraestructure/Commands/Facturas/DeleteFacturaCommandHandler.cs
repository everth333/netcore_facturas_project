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

namespace NetCore.Infraestructure.Commands.Facturas
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<Factura>>
    {
        private readonly IFacturaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(IFacturaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Factura>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var factura = await _repository.FindByIdAsync(request.Id);

            if (factura == null)
            {
                return new Response<Factura>("Factura No Encontrada.");
            }

            _repository.Delete(factura);
            await _unitOfWork.CompleteAsync();

            return new Response<Factura>(factura);
        }
    }
}
