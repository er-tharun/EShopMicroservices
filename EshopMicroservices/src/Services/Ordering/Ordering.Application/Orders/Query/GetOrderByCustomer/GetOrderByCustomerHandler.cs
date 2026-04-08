namespace Ordering.Application.Orders.Query.GetOrderByCustomer
{
    public class GetOrderByCustomerHandler
        (IApplicationDbContext context)
        : IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery query, CancellationToken cancellationToken)
        {
            var order = await context.Order
                .Where(a => a.CustomerId.Equals(query.Id))
                .ToListAsync(cancellationToken);
            return new GetOrderByCustomerResult(order.ToOrderDto().First());
        }
    }
}
