using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain;
using MediatR;
using NetCore.Domain.Entities;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class UpdateDetalleCommand : IRequest<Response<Detalle>>
    {
        public int Id { get; private set; }
        public int IdFactura { get; private set; }
        public int IdProducto { get; private set; }
        public decimal Precio { get; private set; }
        public int Cantidad { get; private set; }

        public UpdateDetalleCommand(int id, int idfactura, int idproducto, decimal precio, int cantidad)
        {
            this.Id = id;
            this.IdFactura = idfactura;
            this.IdProducto = idproducto;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }

    }
}
