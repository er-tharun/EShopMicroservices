using Ordering.Application.Data;
using Ordering.Application.Exceptions;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Command.UpdateOrder
{
    public class UpdateOrderHandler
        (IApplicationDbContext context)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var existingOrder = await context.Order.FindAsync(command.Order.OrderId, cancellationToken);
            if(existingOrder is null)
                throw new OrderNotFoundException("Order", command.Order.OrderId);
            context.Order.Update(UpdateOrder(command.Order));
            await context.SaveChangesAsync(cancellationToken);

            return new UpdateOrderResult(true);
        }

        private Order UpdateOrder(OrderDto orderDto)
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
                orderId: OrderId.Of(orderDto.OrderId),
                customerId: CustomerId.Of(orderDto.CustomerId),
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: payment);

            foreach (var item in orderDto.OrderItems)
                order.Add(ProductId.Of(item.ProductId), item.Quantity, item.Price);

            return order;
        }
    }
}
