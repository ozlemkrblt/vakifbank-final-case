using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Commands.DeleteReceipt;
public class DeleteReceiptCommandValidator : AbstractValidator<DeleteReceiptCommand>
{
    public DeleteReceiptCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("ReceiptId must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("ReceiptId must be greater than 0.");
    }
}

