using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS.Persistance.Contexts
{
    public sealed class GiftShopDbContextInitializer
    {
        private readonly GiftShopDBContext _context;

        public GiftShopDbContextInitializer(GiftShopDBContext context)
        {
            _context = context;
        }

        public async Task Run()
        {
            if(_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                await _context.Database.MigrateAsync();
            }
        }

    }
}
