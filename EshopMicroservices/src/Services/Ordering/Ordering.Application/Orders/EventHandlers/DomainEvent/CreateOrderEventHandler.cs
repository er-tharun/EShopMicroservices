namespace Ordering.Application.Orders.EventHandlers.DomainEvent
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
