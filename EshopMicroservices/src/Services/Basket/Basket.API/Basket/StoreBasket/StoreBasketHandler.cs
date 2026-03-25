using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("User Name Cannot be empty");
        }
    }

    public class StoreBasketHandler
        (IBasketRepository basketRepo, DiscountProtoService.DiscountProtoServiceClient discountService) 
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            await DetectDiscount(request.Cart, cancellationToken);
            var result = await basketRepo.StoreBasketAsync(request.Cart, cancellationToken);
            return new StoreBasketResult(result);
        }

        private async Task DetectDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items) 
            {
                var discount = await discountService.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
                item.Price -= discount.Amount;
            }
        }
    }
}
