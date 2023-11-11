using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Commands.DeletePayment;
public class DeleteCreditAccountCommandValidator : AbstractValidator<DeletePaymentCommand>
{
    public DeleteCreditAccountCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Payment Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Payment Id must be greater than 0.");
    }
}

