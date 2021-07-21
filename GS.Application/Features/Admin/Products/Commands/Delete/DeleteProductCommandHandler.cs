using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Products.Commands.Delete
{
    public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;

        public DeleteProductCommandHandler(IReadOnlyRepository readOnlyRepository, IRepository repository)
        {
            _readOnlyRepository = readOnlyRepository;
            _repository = repository;
        }

        public async Task<Response<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepository.FirstAsync<Product>(
                p => p.Id.Equals(request.Id) && p.Status != EnabledStatus.Deleted);

            if (entity == null)
            {
                throw new ApiException("Product not found");
            }

            entity.Status = EnabledStatus.Deleted;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return new Response<Guid>(entity.Id);
        }
    }
}
