using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class ImageConfiguration
    {
        public ImageConfiguration(EntityTypeBuilder<Image> entityBuilder)
        {
            //entityBuilder.Property(i => i.CreatedBy).IsRequired();
            entityBuilder.Property(i => i.ProductId).IsRequired();
            entityBuilder.HasIndex(i => i.ProductId).IsClustered();
            entityBuilder.HasIndex(i => new { i.CreatedBy, i.LabelName }).IsClustered(false);
        }
    }
}
