using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> category, decimal Price, string ImageName, string Description);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender, CancellationToken ct) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command, ct);

                var responose = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{responose.Id}", responose);

            })
            .WithName("Create Product")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Creates a new product");
        }
    }
}
