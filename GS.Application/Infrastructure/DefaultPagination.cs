using GS.Application.Contracts.Persistence;
using GS.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Infrastructure
{
    public class DefaultPagination : IPaginator
    {
        public async Task<PaginatedResponse<TItem>> CreatePageAsync<TCount, TItem>(
            IRepositoryBase repository,
            IQueryable<TCount> countQuery,
            IQueryable<TItem> itemsQuery,
            int page, int pageSize, CancellationToken cancellationToken = default)
            where TCount : class
            where TItem : class
        {
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

            ValidatePaging(page, pageSize);

            var count = await repository.CountAsync(countQuery, cancellationToken);

            var items = await repository.ListAsync(itemsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize), cancellationToken);

            return PaginatedResponse.From(items, count, page, pageSize);
        }

        public async Task<AllItemsResult<TItem>> CreateAllAsync<TItem>(IRepositoryBase repository, IQueryable<TItem> itemsQuery, CancellationToken cancellationToken = default) where TItem : class
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            if (itemsQuery == null)
            {
                throw new ArgumentNullException(nameof(itemsQuery));
            }

            var items = await repository.ListAsync(itemsQuery, cancellationToken);
            return AllItemsResult.From(items);
        }

        public void ValidatePaging(int page, int pageSize)
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
