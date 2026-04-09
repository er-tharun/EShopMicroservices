using Basket.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketRequest(BasketCheckoutDto BasketDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckoutBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CheckoutBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("Basket Checkout")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Basket Checkout")
            .WithSummary("Basket Checkout");
        }
    }
}
