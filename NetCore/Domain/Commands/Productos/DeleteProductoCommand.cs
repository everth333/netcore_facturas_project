using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Communication;
using NetCore.Entities;
using MediatR;

namespace NetCore.Domain.Commands.Productos
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
