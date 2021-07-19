using GS.Application.Contracts.Persistence;
using GS.Application.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Infrastructure
{
    public interface IPaginator
    {
        Task<PaginatedResponse<TItem>> CreatePageAsync<TCount, TItem>(
            IRepositoryBase repository, 
            IQueryable<TCount> countQuery,
            IQueryable<TItem> itemsQuery,
            int page, 
            int pageSize, 
            CancellationToken cancellationToken = default) where TCount : class where TItem : class;
    }
}
