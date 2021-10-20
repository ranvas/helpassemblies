using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mzt.MTDATA.Utils
{
    public static class LinqUtils
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }
    }
}
