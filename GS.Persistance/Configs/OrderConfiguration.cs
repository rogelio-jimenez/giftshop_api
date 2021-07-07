using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order> entityBuilder)
        {
            //entityBuilder.Property(o => o.CreatedBy).IsRequired();
            entityBuilder.Property(o => o.Total).IsRequired();
            entityBuilder.HasIndex(o => o.CreatedBy).IsClustered();
        }
    }
}
