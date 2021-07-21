using GS.Application.Contracts.Persistence;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Commands.Delete
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnluRepository;
        private readonly IRepository _repository;

        public DeleteCategoryCommandHandler(IRepository repository, IReadOnlyRepository readOnluRepository)
        {
            _repository = repository;
            _readOnluRepository = readOnluRepository;
        }

        public async Task<Response<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readOnluRepository.FirstAsync<Category>(
                c => c.Id.Equals(request.Id)
                && c.Status != EnabledStatus.Disabled
            );

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id: {request.Id} not found.");
            }

            entity.Status = EnabledStatus.Deleted;
            entity.UpdatedById = request.UpdatedById;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return new Response<Guid>(entity.Id);
        }
    }
}
