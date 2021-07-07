using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ProductConfguration
    {
        public ProductConfguration(EntityTypeBuilder<Product> entityBulider)
        {
            entityBulider.Property(p => p.Price).IsRequired();
            entityBulider.Property(p => p.Name).HasMaxLength(64).IsRequired();
            entityBulider.Property(p => p.Description).HasMaxLength(200).IsRequired();
            entityBulider.Property(p => p.CategoryId).IsRequired();
            entityBulider.Property(p => p.UserId).IsRequired();

            entityBulider.HasIndex(p => new { p.UserId, p.CategoryId }).IsClustered(false);
        }
    }
}
