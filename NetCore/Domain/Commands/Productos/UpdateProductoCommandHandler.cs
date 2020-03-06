using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Communication;
using NetCore.Entities;
using NetCore.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Domain.Commands.Productos
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, Response<Producto>>
    {
        private readonly IProductoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductoCommandHandler(IProductoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Producto>> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _repository.FindByIdAsync(request.Id);

            if (producto == null)
            {
                return new Response<Producto>("Producto No Encontrado.");
            }

            producto.Nombre = request.Nombre;
            producto.Costo = request.Costo;
            producto.Precio = request.Precio;
            producto.Stock = request.Stock;

            _repository.Update(producto);
            await _unitOfWork.CompleteAsync();

            return new Response<Producto>(producto);
        }
    }
}
