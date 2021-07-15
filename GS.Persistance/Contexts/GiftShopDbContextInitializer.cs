using GS.Application.Contracts;
using GS.Persistance.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GS.Persistance.Contexts
{
    public sealed class GiftShopDbContextInitializer
    {
        private readonly GiftShopDBContext _context;
        private readonly IDateTime _dateTime;

        public GiftShopDbContextInitializer(GiftShopDBContext context, IDateTime dateTime)
        {
            _context = context;
            this._dateTime = dateTime;
        }

        private void CheckUserAdminId(Guid userAdminId)
        {
            if (userAdminId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userAdminId));
            }
        }

        public async Task Run(Guid userAdminId)
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                await _context.Database.MigrateAsync();
            }

            CheckUserAdminId(userAdminId);
            await InitializeCategories(userAdminId);
        }

        private async Task InitializeCategories(Guid userAdminId)
        {
            var categories = new SeedCategory(userAdminId, _dateTime);

            if (!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(categories.Items);
                await _context.SaveChangesAsync();
            }
        }
    }
}
