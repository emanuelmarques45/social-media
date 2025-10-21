using System.Linq.Expressions;

namespace SocialMedia.Shared.Helpers.Query
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, Query param) => query.Skip(param.SkipNumber).Take(param.PageSize);

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string? sortBy, bool isDescending)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyInfo = typeof(T).GetProperty(sortBy);

            if (propertyInfo == null)
            {
                // If the property doesn't exist, return the original query
                return query;
            }

            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda(property, parameter);

            var methodName = isDescending ? nameof(Queryable.OrderByDescending) : nameof(Queryable.OrderBy);

            var result = typeof(Queryable).GetMethods()
            .First(i => i.Name == methodName && i.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type)
            .Invoke(null, new object[] { query, lambda });

            return (IQueryable<T>)result!;
        }
    }
}