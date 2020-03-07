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

namespace NetCore.Infraestructure.Commands.Clientes
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<Cliente>>
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(IClienteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Cliente>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.FindByIdAsync(request.Id);

            if (cliente == null)
            {
                return new Response<Cliente>("Cliente No Encontrada.");
            }

            _repository.Delete(cliente);
            await _unitOfWork.CompleteAsync();

            return new Response<Cliente>(cliente);
        }
    }
}
