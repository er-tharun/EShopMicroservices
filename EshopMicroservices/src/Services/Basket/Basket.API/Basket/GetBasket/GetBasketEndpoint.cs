using Basket.API.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketRequest(string UserName);
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket", async ([AsParameters]GetBasketRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetBasketQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetBasketResponse>(); 

                return Results.Ok(response);
            });
        }
    }
}
