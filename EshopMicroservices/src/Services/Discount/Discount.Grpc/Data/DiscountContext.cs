namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
            
        }

        public DbSet<Coupon> Coupon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id=1, ProductName = "Iphone 17 max pro", Amount= 100, Description="Iphone discount"},
                new Coupon { Id=2, ProductName = "Samsung S25", Amount=115, Description="Samsung Discount"}
                );
        }
    }
}
