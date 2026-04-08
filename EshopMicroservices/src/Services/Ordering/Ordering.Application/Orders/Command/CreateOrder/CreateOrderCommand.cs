namespace Ordering.Application.Orders.Command.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

    public record CreateOrderResult(bool IsSuccess);

    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Order name cant be empty");
            RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("Order should contain atleast one item");
            RuleFor(x => x.Order.Payment).NotEmpty().WithMessage("Payment cant be empty in an Order");
        }
    }
}
