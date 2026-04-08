namespace Ordering.API.Endpoints
{
    public record DeleteOrderRequest(Guid Id);
    public record DeleteOrderResponse(bool IsSuccess);
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/order", async (DeleteOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteOrderRequest>();

                var result = await sender.Send(command);

                var response = result.Adapt<DeleteOrderResponse>();

                return Results.Ok(response.IsSuccess);
            })
            .WithName("Delete Order")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Delete Order")
            .WithSummary("Delete Order");
        }
    }
}
