using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.EventHandlers
{
    public class UpdateOrderEventHandler
        (ILogger<UpdateOrderEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update Order handler");
            return Task.CompletedTask;
        }
    }
}
