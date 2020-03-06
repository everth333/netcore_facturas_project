using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Domain;
using MediatR;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Queries.Productos
{
    public class ListProductosQuery : IRequest<IEnumerable<Producto>>
    {
    }
}
