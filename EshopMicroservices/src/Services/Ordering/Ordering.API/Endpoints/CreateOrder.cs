namespace Ordering.API.Endpoints
{
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid OrderId);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, [FromServices] ISender sender) =>
            {
                //var request = new CreateOrderCommand(InitialData.OrdersWithItems.ToOrderDto().First());
                var command = request.Adapt<CreateOrderCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/order/{response.OrderId}", response.OrderId);
            })
            .WithName("Create Order")
            .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Create Order")
            .WithSummary("Create Order");
        }
    }
}
