using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class CartItemConfiguration
    {
        public CartItemConfiguration(EntityTypeBuilder<CartItem> entityBuilder)
        {
            entityBuilder.HasIndex(ci => ci.ProductId).IsClustered();
            //entityBuilder.Property(ci => ci.CreatedBy).IsRequired();
        }
    }
}
