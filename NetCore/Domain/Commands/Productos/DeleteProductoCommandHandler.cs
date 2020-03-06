﻿using System;
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
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, Response<Producto>>
    {
        private readonly IProductoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductoCommandHandler(IProductoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Producto>> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _repository.FindByIdAsync(request.Id);

            if (producto == null)
            {
                return new Response<Producto>("Producto No Encontrado.");
            }

            _repository.Delete(producto);
            await _unitOfWork.CompleteAsync();

            return new Response<Producto>(producto);
        }
    }
}
