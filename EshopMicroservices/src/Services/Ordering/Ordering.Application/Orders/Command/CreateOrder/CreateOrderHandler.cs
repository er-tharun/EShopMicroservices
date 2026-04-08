namespace Ordering.Application.Orders.Command.CreateOrder
{
    public class CreateOrderHandler
        (IApplicationDbContext context)
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = CreateNewOrder(command.Order);
            context.Order.Add(order);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.ID.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, 
                orderDto.BillingAddress.LastName, 
                orderDto.BillingAddress.Email, 
                orderDto.BillingAddress.AddressLine, 
                orderDto.BillingAddress.Country, 
                orderDto.BillingAddress.State, 
                orderDto.BillingAddress.Zipcode);

            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, 
                orderDto.ShippingAddress.LastName, 
                orderDto.ShippingAddress.Email, 
                orderDto.ShippingAddress.AddressLine, 
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.State, 
                orderDto.ShippingAddress.Zipcode);

            var payment = Payment.Of(orderDto.Payment.CardName,
                orderDto.Payment.CardName,
                orderDto.Payment.Expiration,
                orderDto.Payment.Cvv,
                orderDto.Payment.PaymentMethod);

            var order = Order.Create(
                orderId: OrderId.Of(Guid.NewGuid()),
                customerId: CustomerId.Of(orderDto.CustomerId),
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: payment);

            foreach (var item in orderDto.OrderItems)
                order.Add(ProductId.Of(Guid.NewGuid()), item.Quantity, item.Price);

            return order;
        }
    }
}
