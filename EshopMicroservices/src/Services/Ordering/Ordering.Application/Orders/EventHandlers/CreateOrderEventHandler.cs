using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.EventHandlers
{
    public class CreateOrderEventHandler
        (ILogger<CreateOrderEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Event Handler");
            return Task.CompletedTask;
        }
    }
}
