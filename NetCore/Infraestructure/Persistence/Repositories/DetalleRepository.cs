using NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Infraestructure.Persistence.Repositories
{
    public class DetalleRepository : Repository<Detalle>, IDetalleRepository
    {
        public DetalleRepository(NetCoreContext context) : base(context)
        {

        }
    }
}
