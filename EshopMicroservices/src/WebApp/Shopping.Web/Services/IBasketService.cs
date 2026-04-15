namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Post("/basket-service/basket/checkout")]
        public Task<CheckoutBasketResponse> BasketCheckout(BasketCheckoutModal modal);
        [Get("/basket-service/basket/{userName}")]
        public Task<GetBasketResponse> GetBasket(string userName);
        [Post("/basket-service/basket")]
        public Task<string> StoreBasket(StoreBasketRequest request);
        [Delete("/basket-service/basket/{userName}")]
        public Task<bool> DeleteBasket(string userName);

        public async Task<ShoppingCartModal> LoadBasketAsync()
        {
            ShoppingCartModal basket;
            try
            {
                var shoppingCart = await GetBasket("svn");
                basket = shoppingCart.Cart;
            }
            catch
            {
                basket = new ShoppingCartModal
                {
                    UserName = "svn",
                    Items = []
                };
            }
            return basket;
        }
    }
}
