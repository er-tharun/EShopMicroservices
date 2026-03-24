namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketQueryValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name Cannot be empty");
        }
    }

    public class DeleteBasketHandler(IBasketRepository basketRepo) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await basketRepo.DeleteBasket(request.UserName, cancellationToken);
            return new DeleteBasketResult(result);
        }
    }
}
