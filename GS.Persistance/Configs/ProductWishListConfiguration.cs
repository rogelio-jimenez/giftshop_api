using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ProductWishListConfiguration: IEntityTypeConfiguration<ProductWishList>
    {
        public void Configure(EntityTypeBuilder<ProductWishList> builder)
        {
            builder.Property(pwl => pwl.ProductId).IsRequired();
            builder.HasKey(pwl => new { pwl.ProductId, pwl.UserId });
        }
    }
}
