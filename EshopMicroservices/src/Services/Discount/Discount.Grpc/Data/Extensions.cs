namespace Discount.Grpc.Data
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var DbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            DbContext.Database.Migrate();
            return app;
        }
    }
}
