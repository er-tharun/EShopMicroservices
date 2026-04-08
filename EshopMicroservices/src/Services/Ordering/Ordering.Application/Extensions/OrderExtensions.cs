namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDto(this IEnumerable<Order> Order)
        {
            var result = Order.Select(obj =>
                new OrderDto(obj.ID.Value,
                obj.CustomerId.Value,
                obj.OrderName.Value,
                new AddressDto(obj.BillingAddress.FirstName,
                obj.BillingAddress.LastName,
                obj.BillingAddress.EmailAddress,
                obj.BillingAddress.AddressLine,
                obj.BillingAddress.Country,
                obj.BillingAddress.State,
                obj.BillingAddress.ZipCode
                ),
                new AddressDto(obj.ShippingAddress.FirstName,
                obj.ShippingAddress.LastName,
                obj.ShippingAddress.EmailAddress,
                obj.ShippingAddress.AddressLine,
                obj.ShippingAddress.Country,
                obj.ShippingAddress.State,
                obj.ShippingAddress.ZipCode
                ),
                new PaymentDto(obj.Payment.CardName,
                obj.Payment.CardNumber,
                obj.Payment.Expiration,
                obj.Payment.CVV,
                obj.Payment.PaymentMethod
                ),
                obj.OrderItems.Select(a => new OrderItemDto(
                    a.ProductId.Value,
                    a.OrderId.Value,
                    a.Quantity,
                    a.Price
                )).ToList()));
            return result;
        }
    }
}
