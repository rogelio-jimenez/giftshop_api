using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Application.Contracts.Persistence
{
    public static class RepositoryAsyncExtensions
    {
        public static Task<T> FirstAsync<T>(this IRepositoryBase repository, Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (includes is null)
            {
                throw new ArgumentNullException(nameof(includes));
            }

            var query = repository.Query(condition, includes);
            return repository.FirstAsync(query);
        }

        public static Task<int> CountAsync<T>(this IRepositoryBase repository)
            where T : class
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            var query = repository.Query<T>();
            return repository.CountAsync(query);
        }

        public static Task<int> CountAsync<T>(this IRepositoryBase repository, Expression<Func<T, bool>> condition, 
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            var query = repository.Query(condition);
            return repository.CountAsync(query, cancellationToken);
        }

        public static Task<List<T>> ListAsync<T>(this IRepositoryBase repository, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (includes is null)
            {
                throw new ArgumentNullException(nameof(includes));
            }

            var query = repository.Query(null, includes);
            return repository.ListAsync(query);
        }

        public static Task<List<T>> ListAsync<T>(this IRepositoryBase repository, Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (includes is null)
            {
                throw new ArgumentNullException(nameof(includes));
            }

            var query = repository.Query(condition, includes);
            return repository.ListAsync(query);
        }
    }
}
