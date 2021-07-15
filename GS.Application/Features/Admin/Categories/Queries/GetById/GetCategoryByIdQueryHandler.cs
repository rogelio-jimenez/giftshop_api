using AutoMapper;
using GS.Application.Contracts.Repository;
using GS.Application.Models.Category;
using GS.Application.Wrappers;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Queries.GetById
{
    public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryModel>>
    {
        private readonly IRepositoryAsync<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepositoryAsync<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Category with id: {request.Id} not found");
            }

            var entityDto = _mapper.Map<CategoryModel>(entity);
            return new Response<CategoryModel>(entityDto);
        }
    }
}
