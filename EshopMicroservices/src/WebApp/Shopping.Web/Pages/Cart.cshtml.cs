using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Services;

namespace Shopping.Web.Pages
{
    public class CartModel
        (ICatalogService catalogService,
        IBasketService basketService,
        ILogger<CartModel> logger
        ) : PageModel
    {
        public ShoppingCartModal Cart {  get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Cart visited");
            var basketResponse = await basketService.GetBasket("svn");
            Cart = basketResponse.Cart;
            return Page();
        }

        public async Task<IActionResult> RemoveToCartAsync(string cartId, Guid cartItemId)
        {
            var basketResponse = await basketService.GetBasket("svn");
            var objToRemove = basketResponse.Cart.Items.Where(obj => obj.ProductId == cartItemId)?.FirstOrDefault();
            basketResponse.Cart.Items.Remove(objToRemove);
            await basketService.StoreBasket(new StoreBasketRequest(basketResponse.Cart));
            return Page();
        }
    }
}
