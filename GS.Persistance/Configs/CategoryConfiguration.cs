using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(32).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(64);
            builder.HasIndex(c => new { c.Name, c.Description }).IsUnique();
            builder.HasIndex(c => c.UserId);
        }
    }
}
