using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Query.GetOrders
{
    public class GetOrdersHandler
        (IApplicationDbContext context)
        : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = await context.Order
                .Skip(query.pageNumber - 1)
                .Take(query.pageSize)
                .ToListAsync(cancellationToken);

            return new GetOrdersResult(orders.ToOrderDto());
        }
    }
}
