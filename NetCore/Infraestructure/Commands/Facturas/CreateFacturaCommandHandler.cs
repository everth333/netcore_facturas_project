using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Facturas
{
    public class CreateFacturaCommandHandler : IRequestHandler<CreateFacturaCommand, Factura>
    {
        private readonly IFacturaRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFacturaCommandHandler(IFacturaRepository facturaRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Repository = facturaRepository;
        }

        public async Task<Factura> Handle(CreateFacturaCommand request, CancellationToken cancellationToken)
        {
            var factura = new Factura
            {
                IdCliente = request.IdCliente,
                Fecha = request.Fecha,
                Importe = request.Importe,
                Nit = request.Nit,
                Razon_Social = request.Razon_Social,
                Codigo_Control = request.Codigo_Control,
                Modo_Pago = request.Modo_Pago,
                Codigo_Tarjeta = request.Codigo_Tarjeta,
            };

            await _Repository.AddAsync(factura);
            await _unitOfWork.CompleteAsync();

            return factura;
        }
    }
}
