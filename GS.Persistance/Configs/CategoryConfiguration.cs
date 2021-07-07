using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category> entityBulider)
        {
            entityBulider.Property(c => c.Name).HasMaxLength(32).IsRequired();
            entityBulider.Property(c => c.Description).HasMaxLength(64);
            entityBulider.HasIndex(c => new { c.Name, c.Description }).IsUnique();
            entityBulider.HasIndex(c => c.UserId);
        }
    }
}
