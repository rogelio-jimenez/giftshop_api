using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Infrastructure;
using GS.Application.Models.Category;
using GS.Application.Queries;
using GS.Domain.Entities;
using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Categories.Queries.GetPage
{
    public sealed class GetCategoryPageQueryHandler : IQueryHandler<GetCategoryPageQuery, PaginatedResponse<CategoryModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetCategoryPageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResponse<CategoryModel>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Category>(c => c.Status == EnabledStatus.Enabled);

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(
                    c => c.Name.Trim().ToLower().Contains(term) ||
                    c.Description.Trim().ToLower().Contains(term));
            }

            var items = query
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(request.OrderBy, x => x.Name);

            var page = await _paginator.CreatePageAsync(_readOnlyRepository, query, items,
                request.Page, request.PageSize, cancellationToken);

            return page;
        }
    }
}
