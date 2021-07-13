using GS.Application.Contracts.Repository;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GS.Domain.Models;
using System;

namespace GS.Application.Features.Admin.Categories.Commands.Delete
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Category> _repository;

        public DeleteCategoryCommandHandler(IRepositoryAsync<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if( entity == null)
            {
                throw new KeyNotFoundException($"Category with id: {request.Id} not found.");
            }

            entity.Status = EnabledStatus.Deleted;
            await _repository.UpdateAsync(entity);
            return new Response<Guid>(entity.Id);
        }
    }
}
