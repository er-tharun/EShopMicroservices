using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> category, decimal Price, string ImageName, string Description) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { Thread.Sleep(5); });
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
