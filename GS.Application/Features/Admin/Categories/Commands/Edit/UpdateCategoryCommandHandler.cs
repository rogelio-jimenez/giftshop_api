using AutoMapper;
using GS.Application.Contracts.Repository;
using GS.Application.Exceptions;
using GS.Application.Features.Admin.Categories.Commands.Add;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Commands.Edit
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepositoryAsync<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Category.Id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id {request.Category.Id} not found");
            }

            // ToDo: validate if an entity with same name and description exists....

            _mapper.Map(request.Category, entity);
            await _repository.UpdateAsync(entity);

            return new Response<Guid>(entity.Id);
        }
    }
}
