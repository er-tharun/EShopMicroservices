namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        public Task<GetProductResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

        [Get("/catalog-service/products/{Id}")]
        public Task<GetProductByIdResponse> GetProductById(Guid Id);
        [Get("/catalog-service/products/{category}")]
        public Task<GetProductByCategoryResponse> GetProductByCategory(string category);
    }
}
