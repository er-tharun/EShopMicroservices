using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Ordering.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions   
    {
        public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            await SeedAsync(context);

        }

        private static async Task SeedAsync(ApplicationDbContext context)
        {
            if(!context.Customer.Any())
                await SeedCustomerAsync(context);
            if (!context.Product.Any())
                await SeedProductAsync(context);
            if (!context.Order.Any())
                await SeedOrdersWithItems(context);
        }

        private static async Task SeedCustomerAsync(ApplicationDbContext context)
        {
            await context.Customer.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }

        private static async Task SeedProductAsync(ApplicationDbContext context)
        {
            await context.Product.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }

        private static async Task SeedOrdersWithItems(ApplicationDbContext context)
        {
            await context.Order.AddRangeAsync(InitialData.OrdersWithItems);
            await context.SaveChangesAsync();
        }
    }
}
