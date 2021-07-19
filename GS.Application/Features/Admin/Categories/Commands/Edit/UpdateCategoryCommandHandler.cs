using AutoMapper;
using GS.Application.Contracts.Persistence;
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
            var entity = await _readOnlyRepository.FirstAsync<Category>(c => c.Id.Equals(request.Category.Id));

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id {request.Category.Id} not found");
            }

            // ToDo: validate if an entity with same name and description exists....

            _mapper.Map(request.Category, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return new Response<Guid>(entity.Id);
        }
    }
}
