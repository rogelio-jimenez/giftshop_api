using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(oi => oi.OrderId).IsRequired();
            builder.Property(oi => oi.TotalPrice).IsRequired();
            builder.Property(oi => oi.UnitPrice).IsRequired();
            builder.HasIndex(oi => oi.OrderId);
            builder.HasIndex(oi => new { oi.ProductId, oi.UserId });
        }
    }
}
