using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Dtos
{
    public record OrderDto(
        Guid OrderId,
        Guid CustomerId,
        string OrderName,
        AddressDto BillingAddress,
        AddressDto ShippingAddress,
        PaymentDto Payment,
        IList<OrderItemDto> OrderItems
        );
}
