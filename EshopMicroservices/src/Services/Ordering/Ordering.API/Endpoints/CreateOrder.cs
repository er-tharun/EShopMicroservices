using Azure;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Ordering.Application.Dtos;
namespace Ordering.API.Endpoints
{
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid OrderId);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/order", async (CreateOrderRequest request, ISender sender) =>
            {
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
