using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Clientes
{
    public class DeleteClienteCommand : IRequest<Response<Cliente>>
    {
        public int Id { get; private set; }

        public DeleteClienteCommand(int id)
        {
            this.Id = id;
        }

    }
}
