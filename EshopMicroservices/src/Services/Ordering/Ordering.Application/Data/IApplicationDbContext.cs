using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;

namespace Ordering.Application.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customer { get; }
        public DbSet<Product> Product { get; }
        public DbSet<OrderItem> OrderItem { get; }
        public DbSet<Order> Order { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
