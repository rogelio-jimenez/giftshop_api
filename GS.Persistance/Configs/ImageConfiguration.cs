using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.Name).HasMaxLength(64).IsRequired();
            builder.Property(i => i.LabelName).HasMaxLength(64).IsRequired();
            builder.Property(i => i.Url).IsRequired();

            builder.HasIndex(i => new { i.ProductId, i.Name, i.LabelName }).IsUnique();
            builder.HasIndex(i => i.ProductId);
            builder.HasIndex(i => new { i.UserId, i.LabelName });
        }
    }
}
