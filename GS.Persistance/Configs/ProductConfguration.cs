using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ProductConfguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasIndex(p => new { p.UserId, p.CategoryId }).IsClustered(false);
        }
    }
}
