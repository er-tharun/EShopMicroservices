using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class CustomerConfguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID)
                .HasConversion(
                    customerId => customerId.Value,
                    dbId => CustomerId.Of(dbId)
                );

            builder.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Email)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
