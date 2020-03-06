using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;


namespace NetCore.Domain.Queries.Productos
{
    public class GetProductoQuery : IRequest<Entities.Producto>
    {
        public int ProductoId { get; private set; }


        public GetProductoQuery(int productoId)
        {
            this.ProductoId = productoId;
        }

    }
}
