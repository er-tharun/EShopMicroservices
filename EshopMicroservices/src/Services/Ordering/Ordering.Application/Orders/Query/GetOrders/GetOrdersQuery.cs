using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Query.GetOrders
{
    public record GetOrdersQuery(int pageSize = 10, int pageNumber = 1) : IQuery<GetOrdersResult>;
    public record GetOrdersResult(IEnumerable<OrderDto> Order);
}
