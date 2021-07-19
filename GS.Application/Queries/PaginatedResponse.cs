using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Queries
{
    public class PaginatedResponse<T>: ListResponse<T>
    {
        public int Current { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public int TotalPages
        {
            get
            {
                if (PageSize > 0)
                {
                    return (int)Math.Ceiling((double)Total / PageSize);
                }

                return 0;
            }
        }

        public PaginatedResponse(IEnumerable<T> items) 
            : base(items)
        {

        }
    }

    public static class PaginatedResponse
    {
        public static PaginatedResponse<T> From<T>(List<T> items, int total, int current, int pageSize)
        {
            return new PaginatedResponse<T>(items)
            {
                Current = current,
                Total = total,
                PageSize = pageSize
            };
        }
    }
}
