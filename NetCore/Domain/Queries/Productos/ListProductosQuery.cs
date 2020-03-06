using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Entities;
using MediatR;


namespace NetCore.Domain.Queries.Productos
{
    public class ListProductosQuery : IRequest<IEnumerable<Producto>>
    {
    }
}
