using Basket.API.Exception;

namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
            session.Delete<ShoppingCart>(userName);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken)
        {
            var result = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
            if(result == null)
                throw new BasketNotFoundException(userName);
            return result;
        }

        public async Task<string> StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken)
        {
            session.Store<ShoppingCart>(cart);
            await session.SaveChangesAsync(cancellationToken);
            return cart.UserName;
        }
    }
}
