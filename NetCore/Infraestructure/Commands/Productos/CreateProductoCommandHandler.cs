using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NetCore.Domain.Entities;
using NetCore.Framework;
using NetCore.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;

namespace NetCore.Infraestructure.Commands.Productos
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, Producto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }

        public async Task<Producto> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = new Producto
            {
                Nombre = request.Nombre,
                Costo = request.Costo,
                Precio = request.Precio,
                Stock = request.Stock,
            };

            await _productoRepository.AddAsync(producto);
            await _unitOfWork.CompleteAsync();

            return producto;
        }
    }
}
