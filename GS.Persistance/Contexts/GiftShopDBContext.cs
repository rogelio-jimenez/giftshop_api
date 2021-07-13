using GS.Domain.Entities;
using GS.Domain.Models;
using GS.Persistance.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Persistance.Contexts
{
    public class GiftShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductWishList> ProductWishList { get; set; }


        public GiftShopDBContext(DbContextOptions<GiftShopDBContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies configuration from all IEntityTypeConfiguration<TEntity> /> instances that are defined in provided assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GiftShopDBContext).Assembly);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductWishListConfiguration());

            var entities = modelBuilder.Model.GetEntityTypes();
            var entityProperties = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties());

            foreach (var entity in entities)
            {
                var type = entity.ClrType;
                if (type.GetInterfaces().Any(i => IsClosedTypeOf(i, typeof(IStatus<>))))
                {
                    modelBuilder.Entity(type).HasIndex(nameof(IStatus<string>.Status));
                }
            }

            foreach (var property in entityProperties)
            {
                var propType = property.ClrType;
                if (propType == typeof(decimal))
                {
                    property.SetColumnType("decimal(10, 2)");
                }

                if(propType == typeof(IHaveUserCreated))
                {
                    property.SetAnnotation("Required", true);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Added:
                        SetDateCreated(dbEntityEntry);
                        SetDateUpdated(dbEntityEntry);
                        break;
                    case EntityState.Modified:
                        SetDateUpdated(dbEntityEntry);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SetDateCreated(EntityEntry dbEntityEntry)
        {
            if (dbEntityEntry.Entity is IHaveDateCreated haveDateCreated)
            {
                haveDateCreated.DateCreated = DateTime.Now;
            }
        }

        private static void SetDateUpdated(EntityEntry dbEntityEntry)
        {
            if (dbEntityEntry.Entity is IHaveDateUpdated haveDateUpdated)
            {
                haveDateUpdated.DateUpdated = DateTime.Now;
            }
        }

        private static bool IsClosedTypeOf(Type type, Type genericInterfaceType)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == genericInterfaceType;
        }

    }
}

