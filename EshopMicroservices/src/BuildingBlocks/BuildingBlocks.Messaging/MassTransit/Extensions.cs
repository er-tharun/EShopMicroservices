using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BuildingBlocks.Messaging.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddMessagingService(this IServiceCollection serviceCollection,
            IConfiguration configuration, Assembly? assembly)
        {
            serviceCollection.AddMassTransit(mt =>
            {
                mt.SetKebabCaseEndpointNameFormatter();

                if (assembly != null)
                    mt.AddConsumers(assembly);

                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["MessagingService:Host"], settings =>
                    {
                        settings.Username(configuration["MessagingService:UserName"]!);
                        settings.Password(configuration["MessagingService:Password"]!);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            return serviceCollection;
        }
    }
}
