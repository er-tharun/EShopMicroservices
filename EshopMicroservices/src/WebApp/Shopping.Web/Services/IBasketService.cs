namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Post("/basket-service/basket/checkout")]
        public Task<CheckoutBasketResponse> BasketCheckout(BasketCheckoutModal modal);
        [Get("/basket-service/basket")]
        public Task<ShoppingCartModal> GetBasket(string userName);
        [Post("/basket-service/basket")]
        public Task<string> StoreBasket(ShoppingCartModal modal);
        [Delete("/basket-service/basket/{userName}")]
        public Task<bool> DeleteBasket(string userName);
    }
}
