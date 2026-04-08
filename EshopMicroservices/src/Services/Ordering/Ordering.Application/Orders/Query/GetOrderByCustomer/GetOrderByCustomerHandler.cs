using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

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
