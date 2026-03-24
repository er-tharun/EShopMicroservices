namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken);
        Task<string> StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken);
        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken);
    }
}
