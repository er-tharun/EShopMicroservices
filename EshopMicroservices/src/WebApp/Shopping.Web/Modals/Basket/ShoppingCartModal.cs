namespace Shopping.Web.Modals.Basket
{
    public class ShoppingCartModal
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItemModal> Items { get; set; } = new();
        public decimal Price => Items.Sum(x => x.Price * x.Quantity);
    }

    public record GetBasketResponse(ShoppingCartModal Cart);
    public record StoreBasketRequest(ShoppingCartModal Cart);
    public record StoreBasketResponse(string UserName);
    public record CheckoutBasketRequest(BasketCheckoutModal BasketDto);
    public record CheckoutBasketResponse(bool IsSuccess);
}
