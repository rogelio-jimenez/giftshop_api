using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ProductWishListConfiguration
    {
        public ProductWishListConfiguration(EntityTypeBuilder<ProductWishList> entityBuilder)
        {
            entityBuilder.Property(pwl => pwl.ProductId).IsRequired();
            entityBuilder.HasKey(pwl => new { pwl.ProductId, pwl.UserId });
        }
    }
}
