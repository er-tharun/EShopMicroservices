namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query<Product>().Where(obj => obj.Id == request.Id).FirstOrDefaultAsync();
            if (result == null)
                throw new ProductNotFoundException(request.Id);
            return new GetProductByIdResult(result!);
        }
    }
}
