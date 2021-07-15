using Ardalis.Specification;
using AutoMapper;
using GS.Application.Common.Extensions;
using GS.Application.Common.Pagination;
using GS.Application.Contracts.Pagination;
using GS.Application.Contracts.Repository;
using GS.Application.Models.Category;
using GS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace GS.Application.Features.Admin.Categories.Queries.GetPage
{
    public sealed class GetCategoryPageQueryHandler : IRequestHandler<GetCategoryPageQuery, IListResponseModel<CategoryModel>>
    {
        private readonly IRepositoryAsync<Category> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCategoryPageQueryHandler(IRepositoryAsync<Category> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<IListResponseModel<CategoryModel>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            var query = await _repositoryAsync.ListAsync(new PagedCategorySpecification(request));
            var categories = _mapper.Map<List<CategoryModel>>(query);

            var result = new ListResponseModel<CategoryModel>(request, query.Count, categories);
            return result;
        }
    }

    public class PagedCategorySpecification: Specification<Category>
    {
        public PagedCategorySpecification(GetCategoryPageQuery request)
        {
            Query.ApplyPaging(request.PageSize, request.PageIndex);

            //if (!string.IsNullOrEmpty(request.OrderBy))
            //{
            //    Query.ApplyOrder(request.OrderBy);
            //}

            if (!string.IsNullOrEmpty(request.Filter))
            {
                Query.Where(c => 
                    c.Name.Trim().ToLower().Contains(request.Filter.ToLower())
                    || c.Description.Trim().ToLower().Contains(request.Filter));
            }
        }
    }
}
