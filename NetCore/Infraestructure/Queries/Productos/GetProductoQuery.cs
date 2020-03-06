using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Queries.Productos
{
    public class GetProductoQuery : IRequest<Producto>
    {
        public int ProductoId { get; private set; }


        public GetProductoQuery(int productoId)
        {
            this.ProductoId = productoId;
        }

    }
}
