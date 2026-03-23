namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> category, decimal Price, string ImageName, string Description) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be null");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be null");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greator than 0");
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("ImageName cannot be null");
            RuleFor(x => x.category).NotEmpty().WithMessage("Category cannot be null");
        }
    }
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
