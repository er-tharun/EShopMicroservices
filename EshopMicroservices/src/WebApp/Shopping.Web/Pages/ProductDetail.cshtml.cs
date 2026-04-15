using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class ProductDetailModel
        (ICatalogService catalogService,
        IBasketService basketService,
        ILogger<IndexModel> logger)
        : PageModel
    {
        public ProductModal Product { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid productId)
        {
            var catalogResponse = await catalogService.GetProductById(productId);
            Product = catalogResponse.Product;
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
