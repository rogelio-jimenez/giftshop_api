using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class CartItemConfiguration: IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(ci => ci.ProductId).IsRequired();
            builder.Property(ci => ci.UnitPrice).IsRequired();
            builder.Property(ci => ci.TotalPrice).IsRequired();
            builder.Property(ci => ci.Quantity).IsRequired();
        }
    }
}
