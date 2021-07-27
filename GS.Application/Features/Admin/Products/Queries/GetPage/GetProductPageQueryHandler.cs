using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Infrastructure;
using GS.Application.Queries;
using GS.Domain.Entities;
using GS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Features.Admin.Products.Queries.GetPage
{
    public sealed class GetProductPageQueryHandler : IQueryHandler<GetProductPageQuery, PaginatedResponse<ProductListItemModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetProductPageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResponse<ProductListItemModel>> Handle(GetProductPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Product>(p => p.Status == EnabledStatus.Enabled);

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Trim().Contains(term)
                    || p.Description.ToLower().Trim().Contains(term)
                    || (p.Category != null && p.Category.Name.ToLower().Trim().Contains(term))
                );
            }

            var items = query.ProjectTo<ProductListItemModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(request.OrderBy, x => x.Name);

            var page = await _paginator.CreatePageAsync(_readOnlyRepository, query, items, request.Page,
                request.PageSize, cancellationToken);

            return page;
        }
    }
}
