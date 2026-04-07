using Ordering.Application.Data;

namespace Ordering.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext)
            :base(dbContext)
        {
            
        }

        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<Product> Product => Set<Product>();
        public DbSet<OrderItem> OrderItem => Set<OrderItem>();
        public DbSet<Order> Order => Set<Order>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
