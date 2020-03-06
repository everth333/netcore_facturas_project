using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Communication;
using NetCore.Entities;
using MediatR;

namespace NetCore.Domain.Commands.Productos
{
    public class UpdateProductoCommand : IRequest<Response<Producto>>
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Stock { get; private set; }

        public UpdateProductoCommand(int id, string nombre, decimal costo, decimal precio, decimal stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Costo = costo;
            this.Precio = precio;
            this.Stock = stock;
        }

    }
}
