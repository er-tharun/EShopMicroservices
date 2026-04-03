using Ordering.Domain.Enums;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID)
                .HasConversion(
                    orderId => orderId.Value,
                    dbId => OrderId.Of(dbId)
                );

            builder.Property(o => o.CustomerId).IsRequired();
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            builder.HasMany<OrderItem>(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(o => o.OrderId)
                .IsRequired();

            builder.ComplexProperty(o => o.OrderName, nameBuilder =>
            {
                nameBuilder.Property(o => o.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

            builder.ComplexProperty(o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(o => o.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(o => o.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(o => o.EmailAddress)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.State)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.ZipCode)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
            {
                addressBuilder.Property(o => o.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(o => o.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(o => o.EmailAddress)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.State)
                    .HasMaxLength(50);

                addressBuilder.Property(o => o.ZipCode)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.ComplexProperty(o => o.Payment, paymenBuilder =>
            {
                paymenBuilder.Property(o => o.CardName)
                    .HasMaxLength(50);

                paymenBuilder.Property(o => o.CardNumber)
                    .HasMaxLength(16)
                    .IsRequired();

                paymenBuilder.Property(o => o.Expiration)
                    .HasMaxLength(5)
                    .IsRequired();

                paymenBuilder.Property(o => o.CVV)
                    .HasMaxLength(3)
                    .IsRequired();

                paymenBuilder.Property(o => o.PaymentMethod)
                    .IsRequired();
            });

            builder.Property(o => o.Status)
                .HasConversion(
                    s => s.ToString(),
                    str => (OrderStatus)Enum.Parse(typeof(OrderStatus), str)
                );

            builder.Property(o => o.TotalPrice)
                .IsRequired();
        }
    }
}
