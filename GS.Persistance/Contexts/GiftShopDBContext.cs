using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GS.Persistance.Contexts
{
    public class GiftShopDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductWishList> ProductWishList { get; set; }


        public GiftShopDBContext(DbContextOptions<GiftShopDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies configuration from all IEntityTypeConfiguration<TEntity> /> instances that are defined in provided assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GiftShopDBContext).Assembly);

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
