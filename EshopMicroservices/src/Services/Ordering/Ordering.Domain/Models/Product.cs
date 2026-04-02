using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Models
{
    public class Product:Entity<ProductId>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Product Create(string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            return new Product
            {
                ID = ProductId.Of(Guid.NewGuid()),
                Name = name,
                Price = price
            };
        }
    }
}
