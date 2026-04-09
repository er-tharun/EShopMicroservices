namespace Ordering.Application.Orders.Query.GetOrderByName
{
    public class GetOrderByNameHandler
        (IApplicationDbContext context)
        : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
        {
            var order = await context.Order
                .Include(o => o.OrderItems)
                .Where(a => a.OrderName.Value.Equals(query.OrderName))
                .ToListAsync(cancellationToken);
            return new GetOrderByNameResult(order.ToOrderDto().First());
        }
    }
}
