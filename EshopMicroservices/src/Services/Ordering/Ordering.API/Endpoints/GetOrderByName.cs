using Ordering.Application.Orders.Query.GetOrderByName;

namespace Ordering.API.Endpoints
{
    public record GetOrderByNameRequest(string OrderName);
    public record GetOrderByNameResponse(OrderDto Order);
    public class GetOrderByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{OrderName}", async ([AsParameters] GetOrderByNameRequest request, [FromServices] ISender sender) =>
            {
                var query = request.Adapt<GetOrderByNameQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetOrderByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("Get Order By Order Name")
            .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Get Order By Order Name")
            .WithSummary("Get Order By Order Name");
        }
    }
}
