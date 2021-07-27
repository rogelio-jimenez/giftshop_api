using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Infrastructure;
using GS.Application.Queries;
using GS.Domain.Entities;
using GS.Domain.Models;
using MediatR;

namespace GS.Application.Features.Admin.ProductImages.Queries.GetByProductId
{
    public class GetImagesPageQueryHandler : IRequestHandler<GetImagesPageQuery, PaginatedResponse<ListItemImageModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetImagesPageQueryHandler(IReadOnlyRepository readOnlyRepo, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepo = readOnlyRepo;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResponse<ListItemImageModel>> Handle(GetImagesPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepo.Query<Image>(i => i.ProductId.Equals(request.ProductId) && i.Status.Equals(EnabledStatus.Enabled));

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(i => i.LabelName.ToLower().Trim().Contains(term));
            }

            var items = query
                .ProjectTo<ListItemImageModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(request.OrderBy, x => x.LabelName);

            var page = await _paginator.CreatePageAsync(_readOnlyRepo, query, items, request.Page, request.PageSize, cancellationToken);
            return page;
        }
    }
}