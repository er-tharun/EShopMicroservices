using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Models
{
    public class Product:Entity<ProductId>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Product Create(ProductId id, string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            return new Product
            {
                ID = id,
                Name = name,
                Price = price
            };
        }
    }
}
