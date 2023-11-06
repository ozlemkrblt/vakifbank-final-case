using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderOperations.Commands.DeleteOrder;
public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");
    }
}

