using System;
using System.Linq;
using System.Linq.Expressions;

namespace GS.Application.Infrastructure
{
    public static class OrderByExtensions
    {
        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable,
            string sorts)
        {
            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable,
            params string[] sorts)
        {
            var sort = new SortCollection<TSource>(sorts);
            return sort.Apply(queryable);
        }

        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable,
            string sorts,
            out SortCollection<TSource> sortCollection)
        {
            sortCollection = new SortCollection<TSource>(sorts);
            return sortCollection.Apply(queryable);
        }

        public static IQueryable<TSource> OrderByOrDefault<TSource, TProp>(this IQueryable<TSource> queryable, string sorts,
            Expression<Func<TSource, TProp>> sortDefaultExpression)
        {

            var sort = new SortCollection<TSource>(sorts);

            if (sort.Sorts == null || (sort.Sorts != null && sort.Sorts.Count == 0))
            {
                return queryable.OrderBy(sortDefaultExpression);
            }
            return sort.Apply(queryable);
        }

    }
}
