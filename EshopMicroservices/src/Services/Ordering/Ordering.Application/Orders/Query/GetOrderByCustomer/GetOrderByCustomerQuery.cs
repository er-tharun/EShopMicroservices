using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Query.GetOrderByCustomer
{
    public record GetOrderByCustomerQuery(Guid Id) :ICommand<GetOrderByCustomerResult> ;

    public record GetOrderByCustomerResult(OrderDto Order);
}
