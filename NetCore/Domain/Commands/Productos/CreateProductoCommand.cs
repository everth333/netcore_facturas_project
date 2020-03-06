using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Entities;
using MediatR;

namespace NetCore.Domain.Commands.Productos
{
    public class CreateProductoCommand: IRequest<Producto>
    {

        public string Nombre { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Stock { get; private set; }


        public CreateProductoCommand(string nombre, decimal costo, decimal precio, decimal stock)
        {
            this.Nombre = nombre;
            this.Costo = costo;
            this.Precio = precio;
            this.Stock = stock;
        }


    }
}
