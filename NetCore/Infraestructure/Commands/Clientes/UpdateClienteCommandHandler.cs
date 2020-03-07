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

namespace NetCore.Infraestructure.Commands.Clientes
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<Cliente>>
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClienteCommandHandler(IClienteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Cliente>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.FindByIdAsync(request.Id);

            if (cliente == null)
            {
                return new Response<Cliente>("Cliente No Encontrada.");
            }

            cliente.Nombre = request.Nombre;
            cliente.Apellidos = request.Apellidos;
            cliente.FechaNaciemiento = request.FechaNaciemiento;
            cliente.Email = request.Email;
            cliente.Telefono = request.Telefono;
            cliente.Direccion = request.Direccion;


            _repository.Update(cliente);
            await _unitOfWork.CompleteAsync();

            return new Response<Cliente>(cliente);
        }
    }
}
