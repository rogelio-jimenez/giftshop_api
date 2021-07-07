using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class ProductConfguration
    {
        public ProductConfguration(EntityTypeBuilder<Product> entityBulider)
        {
            //entityBulider.Property(p => p.CreatedBy).IsRequired();
            entityBulider.HasIndex(p => new { p.CreatedBy, p.CategoryId }).IsClustered();
        }
    }
}
