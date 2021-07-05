using GS.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Identity
{
    public class GiftShopIdentityDbContext: IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public GiftShopIdentityDbContext(DbContextOptions<GiftShopIdentityDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("auth");
        }
    }
}
