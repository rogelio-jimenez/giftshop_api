using GS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GS.Identity
{
    public class GiftShopIdentityInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly GiftShopIdentityDbContext _context;

        public GiftShopIdentityInitializer(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, GiftShopIdentityDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task Run(string adminEmail)
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                await _context.Database.MigrateAsync();
            }

            if (!await _roleManager.RoleExistsAsync(Role.Admin))
            {
                await _roleManager.CreateAsync(new Role { Name = Role.Admin });
            }

            if (await _userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new ApplicationUser
                {
#if DEBUG
                    Id = Guid.Parse("c31de770-af00-442b-be2e-bd6e5dffde03"),
#endif
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var identityResult = await _userManager.CreateAsync(user, "P@ssw0rd");
                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.Admin);
                }
            }
        }



    }
}
