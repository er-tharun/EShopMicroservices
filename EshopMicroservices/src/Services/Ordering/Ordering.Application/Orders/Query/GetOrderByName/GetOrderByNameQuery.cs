namespace Ordering.Application.Orders.Query.GetOrderByName
{
    public record GetOrderByNameQuery(string OrderName) : IQuery<GetOrderByNameResult>;

    public record GetOrderByNameResult(OrderDto Order);
}
