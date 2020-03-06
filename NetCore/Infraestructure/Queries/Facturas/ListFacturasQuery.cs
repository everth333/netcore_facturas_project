using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Queries.Facturas
{
    public class ListFacturasQuery : IRequest<IEnumerable<Factura>>
    {
    }
}
