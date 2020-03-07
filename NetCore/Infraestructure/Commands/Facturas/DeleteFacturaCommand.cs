using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using MediatR;

namespace NetCore.Infraestructure.Commands.Facturas
{
    public class DeleteFacturaCommand : IRequest<Response<Factura>>
    {
        public int Id { get; private set; }

        public DeleteFacturaCommand(int id)
        {
            this.Id = id;
        }

    }
}
