using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Infraestructure.Persistence;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Persistence.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {

        public ProductoRepository(NetCoreContext context): base(context)
        {

        }

    }
}
