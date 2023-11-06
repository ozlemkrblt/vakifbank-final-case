using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Commands.CreateReceipt;
public class CreateReceiptCommandValidator : AbstractValidator<CreateReceiptCommand>
{
    public CreateReceiptCommandValidator()
    {
        RuleFor(x => x.Model.ReceiptInfoId).NotNull().WithMessage("Receipt Info must be given.");
        RuleFor(x => x.Model.OrderId).NotNull().WithMessage("Order Id must be given.");
        RuleFor(x => x.Model.OrderId).GreaterThan(0).WithMessage("Order Id should be 0 or higher than 0");
    }
}

