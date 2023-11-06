using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Commands.DeleteReceiptInfo;
public class DeleteReceiptInfoCommandValidator : AbstractValidator<DeleteReceiptInfoCommand>
{
    public DeleteReceiptInfoCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("ReceiptInfo Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("ReceiptInfo Id must be greater than 0.");
    }
}

