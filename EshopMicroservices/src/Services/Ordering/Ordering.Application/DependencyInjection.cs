using BuildingBlocks.Messaging.Extensions;
using Microsoft.Extensions.Configuration;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            });

            services.AddMessagingService(configuration, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
