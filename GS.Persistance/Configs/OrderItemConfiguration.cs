using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class OrderItemConfiguration
    {
        public OrderItemConfiguration(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.Property(oi => oi.OrderId).IsRequired();
            entityBuilder.Property(oi => oi.TotalPrice).IsRequired();
            entityBuilder.Property(oi => oi.UnitPrice).IsRequired();
            entityBuilder.HasIndex(oi => oi.OrderId);
            entityBuilder.HasIndex(oi => new { oi.ProductId, oi.UserId });
        }
    }
}
