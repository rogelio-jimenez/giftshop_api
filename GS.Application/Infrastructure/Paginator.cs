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
