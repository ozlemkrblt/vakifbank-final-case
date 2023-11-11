using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;
namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithCard;

public class CreatePaymentWithCardCommandValidator : AbstractValidator<CreatePaymentWithCardCommand>
{
    public CreatePaymentWithCardCommandValidator()
    {
        RuleFor(command => command.Model.OrderId).NotNull().WithMessage("OrderId must be given.");
        RuleFor(command => command.Model.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than 0.");

        RuleFor(command => command.Model.PaymentAmount).NotNull().WithMessage("Payment Amount is required.");

        RuleFor(command => command.Model.PaymentType).NotNull().WithMessage("Payment Type is required");
        RuleFor(x => x.Model.PaymentType).IsInEnum().WithMessage("Please provide a valid payment type.");

    }
}

