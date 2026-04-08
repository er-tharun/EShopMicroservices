using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddApplicationServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddApiServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseApiServices();

            if (app.Environment.IsDevelopment())
            {
                app.InitializeDatabaseAsync().GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}
