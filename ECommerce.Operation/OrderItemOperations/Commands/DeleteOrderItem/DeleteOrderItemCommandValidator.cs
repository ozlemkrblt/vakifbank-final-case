using ECommerce.Operation.OrderItemOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderItemOperations.Commands.DeleteOrderItem;
public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
{
    public DeleteOrderItemCommandValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("OrderItem Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("OrderItem Id must be greater than 0.");
    }
}

