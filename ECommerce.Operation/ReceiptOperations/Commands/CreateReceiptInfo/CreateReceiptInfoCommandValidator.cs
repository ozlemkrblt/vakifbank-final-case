using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Commands.CreateReceiptInfo;
public class CreateReceiptInfoCommandValidator : AbstractValidator<CreateReceiptInfoCommand>
{
    public CreateReceiptInfoCommandValidator()
    {
        RuleFor(x => x.Model.RetailerId).NotNull().WithMessage("Retailer Id must be given.");
        RuleFor(x => x.Model.RetailerId).GreaterThan(0).WithMessage("Retailer Id should be higher than 0");


        RuleFor(x => x.Model.ReceiptId).GreaterThan(0).WithMessage("Receipt Id should be higher than 0");

        RuleFor(x => x.Model.AddressId).NotNull().WithMessage("Address Id must be given.");
        RuleFor(x => x.Model.AddressId).GreaterThan(0).WithMessage("Address Id should be higher than 0");


        RuleFor(x => x.Model.RetailerTaxNumber).NotNull().WithMessage("RetailerTaxNumber No must be given.");
        RuleFor(x => x.Model.RetailerTaxNumber).GreaterThan(0).WithMessage("RetailerTaxNumber Id should be higher than 0");


        RuleFor(x => x.Model.MersisNo).NotNull().WithMessage("Mersis No must be given.");
        RuleFor(x => x.Model.MersisNo).GreaterThan(0).WithMessage("Mersis No should be higher than 0");


        RuleFor(x => x.Model.CompanyName).NotEmpty().WithMessage("Company Name is required");
        RuleFor(x => x.Model.CompanyName).MaximumLength(50).WithMessage("Company Name should be maximum 50 characters.");

    }
}

