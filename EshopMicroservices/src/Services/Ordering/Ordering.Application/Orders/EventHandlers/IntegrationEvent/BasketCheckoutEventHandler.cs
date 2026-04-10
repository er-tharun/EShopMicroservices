using BuildingBlocks.Messaging.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Orders.Command.CreateOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.EventHandlers.IntegrationEvent
{
    public class BasketCheckoutEventHandler
        (ILogger<BasketCheckoutEventHandler> logger,
        ISender sender)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Integration Event Triggered : {name}", context.GetType().Name);
            var command = MapToCreateOrder(context.Message);
            await sender.Send(command);
        }

        private CreateOrderCommand MapToCreateOrder(BasketCheckoutEvent context)
        {
            var billingAddress = new AddressDto(context.FirstName, context.LastName, context.EmailAddress,
                context.AddressLine, context.Country, context.State, context.ZipCode);

            var shippingAddress = new AddressDto(context.FirstName, context.LastName, context.EmailAddress,
                context.AddressLine, context.Country, context.State, context.ZipCode);

            var payment = new PaymentDto(context.CardName, context.CardNumber, context.Expiration, context.CVV, context.PaymentMethod);

            var order = new OrderDto(
                Guid.NewGuid(),
                context.CustomerId,
                context.UserName,
                shippingAddress,
                billingAddress,
                payment,
                new List<OrderItemDto>()
                );
            return new CreateOrderCommand(order);
        }
    }
}
