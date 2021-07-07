using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.Property(o => o.Total).IsRequired();
            entityBuilder.HasIndex(o => o.UserId).IsClustered(false);
        }
    }
}
