namespace Ordering.Application.Orders.Query.GetOrderByCustomer
{
    public class GetOrderByCustomerHandler
        (IApplicationDbContext context)
        : IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery query, CancellationToken cancellationToken)
        {
            var order = await context.Order
                .Include(o => o.OrderItems)
                .Where(a => a.CustomerId.Value.Equals(query.Id))
                .ToListAsync(cancellationToken);
            return new GetOrderByCustomerResult(order.ToOrderDto().First());
        }
    }
}
