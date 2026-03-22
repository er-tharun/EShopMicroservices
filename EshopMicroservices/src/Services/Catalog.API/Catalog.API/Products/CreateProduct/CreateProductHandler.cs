using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> category, decimal Price, string ImageName, string Description) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Category = request.category,
                Description = request.Description,
                ImageName = request.ImageName,
                Price = request.Price,
            };

            session.Store(product);

            await session.SaveChangesAsync();

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
