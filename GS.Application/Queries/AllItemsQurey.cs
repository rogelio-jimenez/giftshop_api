namespace GS.Application.Queries
{
    public class AllItemsQuery : ListQuery
    {

    }

    public class AllItemsQuery<T> : AllItemsQuery, IQuery<AllItemsResult<T>>
    {
    }

}