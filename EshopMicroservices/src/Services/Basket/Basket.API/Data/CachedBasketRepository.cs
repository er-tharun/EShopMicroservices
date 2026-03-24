using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository repo, IDistributedCache cache) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
            var result = await repo.DeleteBasket(userName, cancellationToken);
            if(result)
                await cache.RemoveAsync(userName, cancellationToken);
            return result;
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken)
        {
            var result = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrWhiteSpace(result))
                return JsonSerializer.Deserialize<ShoppingCart>(result);
            var basket = await repo.GetBasketAsync(userName, cancellationToken);
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize<ShoppingCart>(basket), cancellationToken);
            return basket;
        }

        public async Task<string> StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken)
        {
            await repo.StoreBasketAsync(cart, cancellationToken);

            await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize<ShoppingCart>(cart), cancellationToken);
            return cart.UserName;
        }
    }
}
