using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Clientes
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Cliente>
    {
        private readonly IClienteRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Repository = clienteRepository;
        }

        public async Task<Cliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                FechaNaciemiento = request.FechaNaciemiento,
                Email = request.Email,
                Telefono = request.Telefono,
                Direccion = request.Direccion
            };

            await _Repository.AddAsync(cliente);
            await _unitOfWork.CompleteAsync();

            return cliente;
        }
    }
}
