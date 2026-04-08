namespace Ordering.Application.Orders.Query.GetOrderByCustomer
{
    public record GetOrderByCustomerQuery(Guid Id) :IQuery<GetOrderByCustomerResult> ;

    public record GetOrderByCustomerResult(OrderDto Order);
}
