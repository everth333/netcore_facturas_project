using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class CreateDetalleCommand : IRequest<Detalle>
    {

        public int IdFactura { get; private set; }
        public int IdProducto { get; private set; }
        public decimal Precio { get; private set; }
        public int Cantidad { get; private set; }


        public CreateDetalleCommand(int idfactura,int idproducto,decimal precio,int cantidad)
        {
            this.IdFactura = idfactura;
            this.IdProducto = idproducto;
            this.Precio = precio;
            this.Cantidad = cantidad;

        }


    }
}
