using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category> entityBulider)
        {
            entityBulider.HasIndex(c => c.Name).IsClustered().IsUnique();
            //entityBulider.Property(c => c.CreatedBy).IsRequired();
            entityBulider.HasIndex(c => c.CreatedBy).IsClustered(false);
        }
    }
}
