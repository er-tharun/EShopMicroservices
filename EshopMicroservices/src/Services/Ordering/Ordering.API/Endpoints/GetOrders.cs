namespace Ordering.API.Endpoints
{
    public record GetOrdersRequest(int PageSize, int PageNumber);
    public record GetOrdersResponse(IEnumerable<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/order", async (GetOrdersRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetOrdersQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetOrdersResponse>();

                return Results.Ok(response);
            })
            .WithName("Get Order")
            .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Get Order")
            .WithSummary("Get Order");
        }
    }
}
