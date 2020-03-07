using MediatR;
using NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Queries.Clientes
{
    public class ListClientesQuery : IRequest<IEnumerable<Cliente>>
    {
    }
}
