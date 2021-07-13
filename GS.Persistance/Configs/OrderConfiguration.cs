using GS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GS.Persistance.Configs
{
    public sealed class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Total).IsRequired();
            builder.HasIndex(o => o.UserId).IsClustered(false);
        }
    }
}
