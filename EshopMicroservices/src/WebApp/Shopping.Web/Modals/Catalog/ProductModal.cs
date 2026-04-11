namespace Shopping.Web.Modals.Catalog
{
    public class ProductModal
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public decimal Price { get; set; } = default!;
        public string ImageName { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public record GetProductsRequest(int? pageNumber = 1, int? pageSize = 10);
    public record GetProductResponse(IEnumerable<ProductModal> Products);
    public record GetProductByCategoryResponse(IEnumerable<ProductModal> Products);
    public record GetProductByIdResponse(ProductModal Product);
}
