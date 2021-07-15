using Ardalis.Specification;
using GS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GS.Application.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static ISpecificationBuilder<T> ApplyPaging<T>(this ISpecificationBuilder<T> query, int pageSize, int pageIndex)
            => query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

        //public static ISpecificationBuilder<T> ApplyOrder<T>(this ISpecificationBuilder<T> query, string oDataOrderByString)
        //{
        //    try
        //    {
        //        if(string.IsNullOrEmpty(oDataOrderByString) || string.IsNullOrWhiteSpace(oDataOrderByString))
        //        {
        //            return query;
        //        }

        //        bool firstOrdering = true;
        //        foreach (var (propertyName, order) in GetOrderEntries(oDataOrderByString, 4))
        //        {
        //            query = ApplyOrdering(query, propertyName, order, firstOrdering);
        //            firstOrdering = false;
        //        }

        //        //TODO: Look into the necessity (or lack thereof) of filtering out multiple orderBy on the same property.
        //        return query;

        //        static IEnumerable<(string propertyPath, OrderTypeEnum order)> GetOrderEntries(string orderByString, int maxOrders)
        //        {
        //            return orderByString
        //                .Split(',', count: maxOrders, StringSplitOptions.RemoveEmptyEntries)
        //                .Select(orderStr =>
        //                {
        //                    var divider = orderStr.IndexOf(' ');
        //                    if (divider < 0) return (propertyPath: orderStr, order: OrderTypeEnum.OrderBy);
        //                    else return (
        //                        propertyPath: orderStr[0..divider],
        //                        order: Enum.Parse<OrderTypeEnum>(orderStr[divider..].Trim(), ignoreCase: true)
        //                    );
        //                });
        //        }

        //        static ISpecificationBuilder<T> ApplyOrdering(ISpecificationBuilder<T> query, string propertyPath, OrderTypeEnum order, bool firstOrdering)
        //        {
        //            var param = Expression.Parameter(typeof(T), "p");
        //            var member = (MemberExpression)propertyPath.Split('/').Aggregate((Expression)param, Expression.Property); //Expression.Property(param, propertyPath);
        //            var exp = Expression.Lambda(member, param);
        //            string methodName = order switch
        //            {
        //                OrderTypeEnum.OrderBy => firstOrdering ? "OrderBy" : "ThenBy",
        //                OrderTypeEnum.OrderByDescending => firstOrdering ? "OrderByDescending" : "ThenByDescending"
        //            };
        //            Type[] types = new Type[] { typeof(Category), exp.Body.Type };
        //            var orderByExp = Expression.Call(typeof(Queryable), methodName, types, query, exp);

        //            return null;
        //            //return query.Provider.CreateQuery<T>(orderByExp);
        //        }

        //        //var sorting = oDataOrderByString.Split(',', StringSplitOptions.RemoveEmptyEntries);
        //        //foreach(var sort in sorting)
        //        //{
        //        //    var sortPropName = sort.Split(' ')[0];
        //        //    var sortPropDir = sort.Split(' ').Length > 0 ? sort.Split(' ')[1] : null;

        //        //    OrderTypeEnum orderDir = Enum.Parse<OrderTypeEnum>(sortPropDir[], ignoreCase: true);
        //        //}

        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new FormatException($"The specified orderBy string '{oDataOrderByString}' is invalid.", e);
        //    }
        //}
    }
}
