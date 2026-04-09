using BuildingBlocks.Messaging.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.EventHandlers.IntegrationEvent
{
    public class BasketCheckoutEventHandler
        (ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Integration Event Triggered : {name}", context.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
