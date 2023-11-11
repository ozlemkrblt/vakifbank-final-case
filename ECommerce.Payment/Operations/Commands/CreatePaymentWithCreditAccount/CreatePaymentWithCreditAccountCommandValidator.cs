using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;
namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithCreditAccount;

public class CreatePaymentWithCreditAccountCommandValidator : AbstractValidator<CreatePaymentWithCreditAccountCommand>
{
    public CreatePaymentWithCreditAccountCommandValidator()
    {
        RuleFor(command => command.Model.OrderId).NotNull().WithMessage("OrderId must be given.");
        RuleFor(command => command.Model.OrderId).GreaterThan(0).WithMessage("Role Id must be greater than 0.");


        RuleFor(command => command.Model.CreditAccountId).NotNull().WithMessage("OrderId must be given.");
        RuleFor(command => command.Model.CreditAccountId).GreaterThan(0).WithMessage("Role Id must be greater than 0.");

        RuleFor(command => command.Model.PaymentAmount).NotNull().WithMessage("Payment Amount is required.");

        RuleFor(command => command.Model.PaymentType).NotNull().WithMessage("Payment Type is required");
        RuleFor(x => x.Model.PaymentType).IsInEnum().WithMessage("Please provide a valid payment type.");
    }
}

