using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class ProductWishListConfiguration
    {
        public ProductWishListConfiguration(EntityTypeBuilder<ProductWishList> entityBuilder)
        {
            entityBuilder.HasKey(pwl => new { pwl.ProductId, pwl.CreatedBy });
        }
    }
}
