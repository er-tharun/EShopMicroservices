namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("User Name Cannot be empty");
            RuleFor(x => x.Cart.Items.Count).LessThan(0).WithMessage("Basket atleast contains 1 Item");
        }
    }

    public class StoreBasketHandler(IBasketRepository basketRepo) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await basketRepo.StoreBasketAsync(request.Cart, cancellationToken);
            return new StoreBasketResult(result);
        }
    }
}
