using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID)
                .HasConversion(
                    productId => productId.Value,
                    dbId => ProductId.Of(dbId)
                );

            builder.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Price)
                .IsRequired();
        }
    }
}
