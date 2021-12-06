using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FMSWebPortal.Shared
{
    public static class Extensions
    {
        public static T RandomElement<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            var r = new Random();
            query = query.Where(expression);
            return query.Skip(r.Next(query.Count())).FirstOrDefault();
        }

        public static T RandomElement<T>(this IQueryable<T> query)
        {
            var random = new Random();
            return query.Skip(random.Next(query.Count())).FirstOrDefault();
        }

        public static IEnumerable<T> RandomElements<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, int quantity)
        {
            quantity = Math.Min(query.Count(), quantity);

            if (quantity == 0)
            {
                return new List<T>();
            }

            var r = new Random();
            query = query.Where(expression);
            return query.Skip(r.Next(query.Count())).Take(quantity);
        }

        public static IEnumerable<T> RandomElements<T>(this IQueryable<T> query, int quantity)
        {
            quantity = Math.Min(query.Count(), quantity);

            if (quantity == 0)
            {
                return new List<T>();
            }

            var r = new Random();
            return query.Skip(r.Next(query.Count())).Take(quantity);
        }
    }
}
