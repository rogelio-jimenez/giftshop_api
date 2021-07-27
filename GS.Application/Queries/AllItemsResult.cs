using System.Collections.Generic;

namespace GS.Application.Queries
{
    public class AllItemsResult<T> : ListResponse<T>
    {
        public AllItemsResult(IEnumerable<T> items) : base(items)
        {
        }
    }

    public static class AllItemsResult
    {
        public static AllItemsResult<T> From<T>(List<T> items)
        {
            return new AllItemsResult<T>(items) { };
        }
    }
}