using AutoMapper;
using GS.Application.Contracts.Persistence;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Commands.Add
{
    public sealed class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Response<Guid>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var _newCategory = _mapper.Map<Category>(request.Category);
            //var _result = await _repositoryAsync.AddAsync(_newCategory);
            var _result = _repository.Add(_newCategory);
            await _repository.SaveChangesAsync();

            return new Response<Guid>(_result.Id);
        }
    }
}
