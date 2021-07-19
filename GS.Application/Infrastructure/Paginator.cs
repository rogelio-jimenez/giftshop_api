using GS.Application.Contracts.Persistence;
using GS.Application.Queries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Infrastructure
{
    public static class Paginator
    {
        public static Task<PaginatedResponse<TItem>> MakePageAsync<TCount, TItem>(this IPaginator paginator, IRepositoryBase repository,
            IQueryable<TCount> countQuery,
            IQueryable<TItem> itemsQuery,
            PaginatedQueryRequest model, CancellationToken cancellationToken = default)
            where TCount : class where TItem : class
        {
            if (paginator == null)
            {
                throw new ArgumentNullException(nameof(paginator));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (countQuery == null)
            {
                throw new ArgumentNullException(nameof(countQuery));
            }

            if (itemsQuery == null)
            {
                throw new ArgumentNullException(nameof(itemsQuery));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return paginator.CreatePageAsync(repository, countQuery, itemsQuery, model.Page, model.PageSize, cancellationToken);
        }

        public static void ValidatePaging(int page, int pageSize)
        {
            if (page < PaginatedQueryRequest.MinPage)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            if (pageSize < PaginatedQueryRequest.MinPageSize || pageSize > PaginatedQueryRequest.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
        }
    }
}
