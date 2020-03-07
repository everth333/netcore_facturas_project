using MediatR;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Queries.Clientes
{
    public class GetDetalleQueryHandler : IRequestHandler<GetClienteQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetDetalleQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException(nameof(request.Id));
            }

            return await _clienteRepository.FindByIdAsync(request.Id);
        }
    }
}
