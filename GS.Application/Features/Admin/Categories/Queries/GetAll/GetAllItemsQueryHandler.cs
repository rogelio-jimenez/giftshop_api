using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GS.Application.Contracts.Persistence;
using GS.Application.Infrastructure;
using GS.Application.Models.Category;
using GS.Application.Queries;
using GS.Domain.Entities;
using GS.Domain.Models;

namespace GS.Application.Features.Admin.Categories.Queries.GetAll
{
    public class GetAllItemsQueryHandler : IQueryHandler<GetAllCategoriesQuery, AllItemsResult<CategoryModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepo;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetAllItemsQueryHandler(IReadOnlyRepository readOnlyRepo, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepo = readOnlyRepo;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<AllItemsResult<CategoryModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepo.Query<Category>(c => c.Status.Equals(EnabledStatus.Enabled));

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower().Trim();
                query = query.Where(c =>
                    c.Name.ToLower().Trim().Contains(term)
                    || c.Description.ToLower().Trim().Contains(term)
                );
            }

            var items = query.ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                        .OrderByOrDefault(request.OrderBy, c => c.Name);

            var allItems = await _paginator.CreateAllAsync(_readOnlyRepo, items, cancellationToken);
            return allItems;
        }
    }
}