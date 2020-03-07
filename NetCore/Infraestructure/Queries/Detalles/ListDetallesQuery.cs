using MediatR;
using NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Queries.Detalles
{
    public class ListDetallesQuery : IRequest<IEnumerable<Detalle>>
    {
    }
}
