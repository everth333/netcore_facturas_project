using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Infraestructure.Communication;
using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Facturas
{
    public class UpdateFacturaCommandHandler : IRequestHandler<UpdateFacturaCommand, Response<Factura>>
    {
        private readonly IFacturaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFacturaCommandHandler(IFacturaRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Factura>> Handle(UpdateFacturaCommand request, CancellationToken cancellationToken)
        {
            var factura = await _repository.FindByIdAsync(request.Id);

            if (factura == null)
            {
                return new Response<Factura>("Factura No Encontrada.");
            }


            factura.IdCliente = request.IdCliente;
            factura.Fecha = request.Fecha;
            factura.Importe = request.Importe;
            factura.Nit = request.Nit;
            factura.Razon_Social = request.Razon_Social;
            factura.Codigo_Control = request.Codigo_Control;
            factura.Modo_Pago = request.Modo_Pago;
            factura.Codigo_Tarjeta = request.Codigo_Tarjeta;


            _repository.Update(factura);
            await _unitOfWork.CompleteAsync();

            return new Response<Factura>(factura);
        }
    }
}
