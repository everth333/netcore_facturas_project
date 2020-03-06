using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Repositories
{
    public class ProductoRepository : Repository<Entities.Producto>, IProductoRepository
    {

        public ProductoRepository(Model.NetCoreContext context): base(context)
        {

        }

    }
}
