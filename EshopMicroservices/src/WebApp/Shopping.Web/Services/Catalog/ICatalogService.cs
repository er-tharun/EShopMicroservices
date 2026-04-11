using Refit;
using Shopping.Web.Modals.Catalog;

namespace Shopping.Web.Services.Catalog
{
    public interface ICatalogService
    {
        [Get("/basket-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        public Task<IEnumerable<ProductModal>> GetProducts(int? pageNumber = 1, int? pageSize = 10);

        [Get("/basket-service/products/{Id}")]
        public Task<GetProductByIdResponse> GetProductById(Guid Id);
        [Get("/basket-service/products/{category}")]
        public Task<GetProductByCategoryResponse> GetProductByCategory(string category);
    }
}
