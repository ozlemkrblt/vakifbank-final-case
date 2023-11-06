using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Commands.UpdateReceiptInfo;
public class UpdateReceiptInfoCommandValidator : AbstractValidator<UpdateReceiptInfoCommand>
{
    public UpdateReceiptInfoCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("ReceiptInfo Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("ReceiptInfo Id must be greater than 0.");

        RuleFor(x => x.Model.AddressId).GreaterThan(0).WithMessage("Address Id should be higher than 0");


        RuleFor(x => x.Model.RetailerTaxNumber).GreaterThan(0).WithMessage("RetailerTaxNumber Id should be higher than 0");


        RuleFor(x => x.Model.MersisNo).GreaterThan(0).WithMessage("Mersis No should be higher than 0");


        RuleFor(x => x.Model.CompanyName).MaximumLength(50).WithMessage("Company Name should be maximum 50 characters.");
    }
}


