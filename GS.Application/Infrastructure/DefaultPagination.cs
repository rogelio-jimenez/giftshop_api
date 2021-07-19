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

            Paginator.ValidatePaging(page, pageSize);

            var count = await repository.CountAsync(countQuery, cancellationToken);

            var items = await repository.ListAsync(itemsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize), cancellationToken);

            return PaginatedResponse.From(items, count, page, pageSize);
        }
    }
}
