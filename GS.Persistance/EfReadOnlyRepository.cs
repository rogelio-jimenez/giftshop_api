using GS.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Persistance
{
    public class EfReadOnlyRepository : EfRepositoryBase, IReadOnlyRepository
    {
        public EfReadOnlyRepository(DbContext context)
            : base(context, true)
        {
        }
    }

    public class EfReadOnlyRepository<TContext> : EfReadOnlyRepository
        where TContext : DbContext
    {
        public EfReadOnlyRepository(TContext context)
            : base(context)
        {
        }
    }
}
