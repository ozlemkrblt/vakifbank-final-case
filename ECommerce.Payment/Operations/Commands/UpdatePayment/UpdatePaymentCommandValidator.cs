using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Commands.UpdatePayment;
public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Payment Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Payment Id must be greater than 0.");

        RuleFor(command => command.Model.PaymentType).IsInEnum().WithMessage("Please provide a valid payment type.");
        RuleFor(command => command.Model.PaymentStatus).IsInEnum().WithMessage("Please provide a valid payment status type.");
        RuleFor(command => command.Model.eft.Status).IsInEnum().WithMessage("Please provide a valid transaction status type.");
        RuleFor(command => command.Model.transfer.Status).IsInEnum().WithMessage("Please provide a valid transaction status type.");
       
    }
}

