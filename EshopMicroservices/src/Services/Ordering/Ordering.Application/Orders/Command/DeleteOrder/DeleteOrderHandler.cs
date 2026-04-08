namespace Ordering.Application.Orders.Command.DeleteOrder
{
    public class DeleteOrderHandler
        (IApplicationDbContext context)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var existingOrder = await context.Order.FindAsync(command.OrderId, cancellationToken);
            if(existingOrder is null)
                throw new OrderNotFoundException("Order", command.OrderId);

            context.Order.Remove(existingOrder);
            await context.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
