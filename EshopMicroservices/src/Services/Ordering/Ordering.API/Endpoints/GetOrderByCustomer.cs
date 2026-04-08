using Ordering.Application.Orders.Query.GetOrderByCustomer;

namespace Ordering.API.Endpoints
{
    public record GetOrderByCustomerRequest(Guid CustomerId);
    public record GetOrderByCustomerResponse(OrderDto Order);
    public class GetOrderByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/order/customer/{Id}", async (GetOrderByCustomer request, ISender sender) =>
            {
                var query = request.Adapt<GetOrderByCustomerQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetOrderByCustomerResult>();

                return Results.Ok(response);
            })
            .WithName("Get Orders by Customer Id")
            .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Get Orders by Customer Id")
            .WithSummary("Get Orders by Customer Id");
        }
    }
}
