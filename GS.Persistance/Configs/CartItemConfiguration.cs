using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class CartItemConfiguration
    {
        public CartItemConfiguration(EntityTypeBuilder<CartItem> entityBuilder)
        {
            entityBuilder.Property(ci => ci.ProductId).IsRequired();
            entityBuilder.Property(ci => ci.UnitPrice).IsRequired();
            entityBuilder.Property(ci => ci.TotalPrice).IsRequired();
            entityBuilder.Property(ci => ci.Quantity).IsRequired();
            //entityBuilder.HasIndex(ci => ci.ProductId).IsClustered(false);
        }
    }
}
