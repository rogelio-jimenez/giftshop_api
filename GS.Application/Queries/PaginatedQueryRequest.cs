using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Queries
{
    public class PaginatedQueryRequest: ListQuery
    {
        public const int MinPage = 1;
        public const int MinPageSize = 1;
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 128;

        private int _page = MinPage;
        private int _pageSize = DefaultPageSize;

        public int Page
        {
            get { return _page; }
            set { _page = Math.Max(value, MinPage); }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = Math.Min(Math.Max(value, MinPageSize), MaxPageSize);
            }
        }
    }

    public class PaginatedQueryRequest<T> : PaginatedQueryRequest, IQuery<PaginatedResponse<T>>
    {

    }
}
