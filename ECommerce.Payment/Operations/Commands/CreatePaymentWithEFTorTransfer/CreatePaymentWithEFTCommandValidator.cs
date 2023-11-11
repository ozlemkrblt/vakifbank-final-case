
using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithEFT;
public class CreatePaymentWithTransferCommandValidator : AbstractValidator<CreatePaymentWithCardCommand>
{
    public CreatePaymentWithTransferCommandValidator()
    {
        RuleFor(command => command.Model.OrderId).NotNull().WithMessage("OrderId must be given.");
        RuleFor(command => command.Model.OrderId).GreaterThan(0).WithMessage("Role Id must be greater than 0.");

        RuleFor(command => command.Model.PaymentAmount).NotNull().WithMessage("Payment Amount is required.");

        RuleFor(command => command.Model.PaymentType).NotNull().WithMessage("Payment Type is required");
        RuleFor(x => x.Model.PaymentType).IsInEnum().WithMessage("Please provide a valid payment type.");

        RuleFor(command => command.Model.eft.Description).NotNull().WithMessage("Description is required..");
        RuleFor(command => command.Model.transfer.Description).NotNull().WithMessage("Description is required..");

        RuleFor(command => command.Model.eft.ReceiverName).NotNull().NotEmpty().WithMessage("Receiver Name must be given .");
        RuleFor(command => command.Model.transfer.ReceiverName).NotNull().NotEmpty().WithMessage("Receiver Name must be given .");

        RuleFor(command => command.Model.eft.ReceiverIBAN).NotNull().NotEmpty().WithMessage("Receiver IBAN must be given .");
        RuleFor(command => command.Model.transfer.ReceiverIBAN).NotNull().NotEmpty().WithMessage("Receiver IBAN must be given .");

        RuleFor(command => command.Model.eft.SenderAccountId).NotNull().NotEmpty().WithMessage("Sender account must be given .");
        RuleFor(command => command.Model.transfer.SenderAccountNo).NotNull().NotEmpty().WithMessage("Sender account must be given .");

   



    }
}

