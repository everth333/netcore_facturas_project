using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Detalles
{
    public class DeleteDetalleCommand : IRequest<Response<Detalle>>
    {
        public int Id { get; private set; }

        public DeleteDetalleCommand(int id)
        {
            this.Id = id;
        }

    }
}
