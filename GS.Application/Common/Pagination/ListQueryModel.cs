using GS.Application.Contracts.Pagination;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace GS.Application.Common.Pagination
{
    public class ListQueryModel<TModel> : IRequest<IListResponseModel<TModel>>
    {
        private const int DEFAULT_PAGESIZE = 10;
        private const int MAX_PAGESIZE = 100;

        [Range(1, int.MaxValue, ErrorMessage = "The minimum page index is 1.")]
        public int PageIndex { get; set; } = 1;

        [Range(1, MAX_PAGESIZE)]
        public int PageSize { get; set; } = DEFAULT_PAGESIZE;

        public string OrderBy { get; set; }

        public string Filter { get; set; }
    }
}
