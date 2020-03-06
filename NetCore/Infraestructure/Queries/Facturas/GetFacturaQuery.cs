using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Queries.Facturas
{
    public class GetFacturaQuery : IRequest<Factura>
    {
        public int FacturaId { get; private set; }


        public GetFacturaQuery(int facturaId)
        {
            this.FacturaId = facturaId;
        }

    }
}
