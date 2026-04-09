using Basket.API.Dtos;
using Basket.API.Exception;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);

    public class CheckoutBasketValidator : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketValidator()
        {
            RuleFor(x => x.BasketDto.UserName).NotEmpty().WithMessage("Username cant be empty");
        }
    }
    public class CheckoutBasketHandler
        (IBasketRepository repo,
        IPublishEndpoint publish)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = await repo.GetBasketAsync(command.BasketDto.UserName, cancellationToken);

            if (basket == null)
                throw new BasketNotFoundException(command.BasketDto.UserName);

            command.BasketDto.TotalPrice = basket.Price;

            var publishEvent = command.BasketDto.Adapt<BasketCheckoutEvent>();

            await publish.Publish(publishEvent, cancellationToken);

            await repo.DeleteBasket(command.BasketDto.UserName, cancellationToken);

            return new CheckoutBasketResult(true);
        }
    }
}
