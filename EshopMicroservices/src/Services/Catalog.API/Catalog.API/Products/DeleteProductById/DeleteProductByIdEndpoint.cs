using Carter;
using MediatR;

namespace Catalog.API.Products.DeleteProductById
{
    public class DeleteProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender sender) =>
            {
                var command = new DeleteProductByIdCommand(Id);

                await sender.Send(command);

                return Results.Accepted;
            })
            .WithName("Delete product by Id")
            .Produces(StatusCodes.Status202Accepted)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Delete product by Id")
            .WithSummary("Delete product by Id");
        }
    }
}
