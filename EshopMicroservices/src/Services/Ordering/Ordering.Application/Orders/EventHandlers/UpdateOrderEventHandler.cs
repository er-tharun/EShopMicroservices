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
