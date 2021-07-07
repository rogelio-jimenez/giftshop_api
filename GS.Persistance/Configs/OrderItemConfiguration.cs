using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public class OrderItemConfiguration
    {
        public OrderItemConfiguration(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.Property(oi => oi.OrderId).IsRequired();
            entityBuilder.Property(oi => oi.TotalPrice).IsRequired();
            entityBuilder.Property(oi => oi.UnitPrice).IsRequired();
            entityBuilder.HasKey(oi => oi.OrderId).IsClustered(false);
            entityBuilder.HasIndex(oi => new { oi.ProductId, oi.CreatedBy });
        }
    }
}
