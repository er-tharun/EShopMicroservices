using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Query.GetOrderByName
{
    public class GetOrderByNameHandler
        (IApplicationDbContext context)
        : ICommandHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
        {
            var order = await context.Order
                .Where(a => a.OrderName.Equals(query.OrderName))
                .ToListAsync(cancellationToken);
            return new GetOrderByNameResult(order.ToOrderDto().First());
        }
    }
}
