using GS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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





    }
}
