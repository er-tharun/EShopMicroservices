using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID)
                .HasConversion(
                    orderItemId => orderItemId.Value,
                    dbId => OrderItemId.Of(dbId)
                );

            builder.Property(o => o.OrderId)
                .HasConversion(
                    orderId => orderId.Value,
                    dbId => OrderId.Of(dbId)
                );

            builder.Property(o => o.ProductId)
                .HasConversion(
                    product => product.Value,
                    dbId => ProductId.Of(dbId)
                );

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.Price)
                .IsRequired();
        }
    }
}
