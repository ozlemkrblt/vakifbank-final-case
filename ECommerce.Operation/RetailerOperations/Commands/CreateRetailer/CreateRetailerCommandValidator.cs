using ECommerce.Operation.RetailerOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RetailerOperations.Commands.CreateRetailer;
public class CreateRetailerCommandValidator : AbstractValidator<CreateRetailerCommand>
{
    public CreateRetailerCommandValidator()
    {
        RuleFor(command => command.Model.RetailerUserName).NotNull().WithMessage("Retailer UserName is required.");
        RuleFor(command => command.Model.RetailerUserName).MaximumLength(20).WithMessage("Retailer UserName length max value is 20.");
    }
}
