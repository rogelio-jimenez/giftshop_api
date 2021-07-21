using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Exceptions;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Commands.Edit
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<Guid>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository repository, IMapper mapper, IReadOnlyRepository readonlyRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _readOnlyRepository = readonlyRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepository.FirstAsync<Category>(c => c.Id.Equals(request.Id));

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id {request.Id} not found.");
            }

            var entityWithSameValues = await _readOnlyRepository.FirstAsync<Category>(
                c => !c.Id.ToString().ToLower().Equals(request.Id.ToString().ToLower())
                && (
                    c.Name.ToLower().Trim().Equals(request.Category.Name.ToLower().Trim())
                    && c.Description.ToLower().Trim().Equals(request.Category.Description.ToLower().Trim())
                )
            );

            if (entityWithSameValues != null)
            {
                throw new ApiException("The category with same name or description already exists.");
            }

            // ToDo: validate if an entity with same name and description exists....

            _mapper.Map(request.Category, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return new Response<Guid>(entity.Id);
        }
    }
}
