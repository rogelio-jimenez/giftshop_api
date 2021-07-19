using GS.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Persistance
{
    public class EfRepository : EfRepositoryBase, IRepository
    {
        public EfRepository(DbContext context): base(context, false)
        {
        }

        public IReadOnlyRepository AsReadOnly()
        {
            return new EfReadOnlyRepository(Context);
        }

        public T Add<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = Set<T>().Add(entity);

            return result.Entity;
        }

        public T Remove<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = Set<T>().Remove(entity);

            return result.Entity;
        }

        public T Update<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            return result.Entity;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }

    public class EfRepository<TContext> : EfRepository
        where TContext : DbContext
    {
        public EfRepository(TContext context)
            : base(context)
        {
        }
    }

}
