using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ImageConfiguration
    {
        public ImageConfiguration(EntityTypeBuilder<Image> entityBuilder)
        {
            entityBuilder.Property(i => i.ProductId).IsRequired();
            entityBuilder.Property(i => i.Name).HasMaxLength(64).IsRequired();
            entityBuilder.Property(i => i.LabelName).HasMaxLength(64).IsRequired();
            entityBuilder.Property(i => i.Url).IsRequired();

            entityBuilder.HasIndex(i => new { i.ProductId, i.Name, i.LabelName }).IsUnique();
            entityBuilder.HasIndex(i => i.ProductId);
            entityBuilder.HasIndex(i => new { i.UserId, i.LabelName });
        }
    }
}
