using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Productos
{
    public class DeleteProductoCommand: IRequest<Response<Producto>>
    {
        public int Id { get; private set; }

        public DeleteProductoCommand(int id)
        {
            this.Id = id;
        }

    }
}
