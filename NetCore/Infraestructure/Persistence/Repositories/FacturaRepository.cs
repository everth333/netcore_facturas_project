using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Persistence.Repositories
{
    public class FacturaRepository:Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(NetCoreContext context): base(context)
        {

        }
    }
}
