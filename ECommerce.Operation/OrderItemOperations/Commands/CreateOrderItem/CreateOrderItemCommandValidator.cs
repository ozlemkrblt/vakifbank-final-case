using FluentValidation;
using System.Text.RegularExpressions;
using ECommerce.Operation.OrderItemOperations.Cqrs;

namespace ECommerce.Operation.OrderItemOperations.Commands.CreateOrderItem;
public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(command => command.Model.ProductId).GreaterThan(0).WithMessage("Product Id must be greater than 0.");
        RuleFor(command => command.Model.ProductId).NotEmpty().WithMessage("Product Id must be given.");

        RuleFor(command => command.Model.ProductQuantity).GreaterThanOrEqualTo(0).WithMessage("Amount must be 0 or greater than 0.");


        RuleFor(command => command.Model.OrderId).GreaterThan(0).WithMessage("Order Id must be greater than 0.");
        RuleFor(command => command.Model.OrderId).NotNull().WithMessage("Order Id must be given.");
    }

}

