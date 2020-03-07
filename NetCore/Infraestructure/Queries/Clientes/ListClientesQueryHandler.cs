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
    public class ListDetallesQueryHandler : IRequestHandler<ListClientesQuery, IEnumerable<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ListDetallesQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(ListClientesQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.ListAsync();
        }
    }
}

