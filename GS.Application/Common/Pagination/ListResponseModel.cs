using GS.Application.Contracts.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Common.Pagination
{
    public class ListResponseModel<TModel> : IListResponseModel<TModel>
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int PageCount { get; private set; }

        public int RowCount { get; private set; }

        public string ActiveFilter { get; private set; }

        public string ActiveOrderBy { get; private set; }

        public int FirstRowOnPage => RowCount <= 0 ? 0 : ((PageIndex - 1) * PageSize) + 1;

        public int LastRowOnPage => Math.Min(PageIndex * PageSize, RowCount);

        public IEnumerable<TModel> Items { get; set; } = new List<TModel>();

        public ListResponseModel(ListQueryModel<TModel> queryModel, int rowCount, IEnumerable<TModel> items)
        {
            Items = items;

            PageIndex = queryModel.PageIndex;
            PageSize = queryModel.PageSize;
            ActiveOrderBy = queryModel.OrderBy;
            ActiveFilter = queryModel.Filter;
            RowCount = rowCount;

            PageCount = (int)Math.Ceiling((double)rowCount / PageSize);
        }
    }
}
