namespace Shopping.Web.Modals.Order
{
    public record OrderModal(
        Guid OrderId,
        Guid CustomerId,
        string OrderName,
        AddressModal BillingAddress,
        AddressModal ShippingAddress,
        PaymentModal Payment,
        IList<OrderItemModal> OrderItems
        );

    public record AddressModal(
        string FirstName,
            string LastName,
            string? Email,
            string AddressLine,
            string Country,
            string State,
            string Zipcode);

    public record OrderItemModal(
        Guid ProductId,
        Guid OrderId,
        int Quantity,
        decimal Price);

    public record PaymentModal(
        string? CardName,
        string CardNumber,
        string Expiration,
        string Cvv,
        int PaymentMethod
        );

    public record GetOrdersRequest(int PageSize, int PageNumber);
    public record GetOrdersResponse(IEnumerable<OrderModal> Orders);

    public record GetOrderByNameRequest(string OrderName);
    public record GetOrderByNameResponse(OrderModal Order);

    public record GetOrderByCustomerRequest(Guid Id);
    public record GetOrderByCustomerResponse(OrderModal Order);
}
