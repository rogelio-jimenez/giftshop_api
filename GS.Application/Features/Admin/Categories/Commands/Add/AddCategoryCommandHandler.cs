using AutoMapper;
using GS.Application.Contracts.Repository;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Commands.Add
{
    public sealed class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Category> _repositoryAsync;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var _newCategory = _mapper.Map<Category>(request.Category);
            var _result = await _repositoryAsync.AddAsync(_newCategory);
            //await _repositoryAsync.SaveChangesAsync();

            return new Response<Guid>(_result.Id);
        }
    }
}
