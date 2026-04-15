using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class ProductModel
        (ICatalogService catalogService,
        IBasketService basketService,
        ILogger<ProductModal> logger
        ): PageModel
    {
        public string SelectedCategory { get; set; }
        public List<string> CategoryList { get; set; }
        public List<ProductModal> ProductList {  get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Visited ProductModel page");
            var categoryResponse = await catalogService.GetProducts();
            ProductList = categoryResponse.Products.ToList();
            var category = categoryResponse.Products.SelectMany(x => x.Category).ToList();
            CategoryList = category;
            SelectedCategory = category.FirstOrDefault();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCart(Guid productId)
        {
            var product = await catalogService.GetProductById(productId);
            var basket = await basketService.LoadBasketAsync();

            basket.Items.Add(new ShoppingCartItemModal
            {
                ProductId = productId,
                ProductName = product.Product.Name,
                Price = product.Product.Price,
                Quantity = 1,
                Colour = "Blue",
            });

            await basketService.StoreBasket(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }
    }
}
