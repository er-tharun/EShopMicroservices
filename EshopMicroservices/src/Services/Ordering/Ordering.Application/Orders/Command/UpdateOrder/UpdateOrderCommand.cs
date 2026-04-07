using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Command.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderValidator: AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Order name cant be empty");
            RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("Order should contain atleast one item");
            RuleFor(x => x.Order.Payment).NotEmpty().WithMessage("Payment cant be empty in an Order");
        }
    }
}
