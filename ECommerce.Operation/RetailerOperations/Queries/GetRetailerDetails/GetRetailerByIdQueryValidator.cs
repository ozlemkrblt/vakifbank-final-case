using ECommerce.Operation.RetailerOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RetailerOperations.Queries.GetRetailerDetails;
public class GetRetailerByIdQueryValidator : AbstractValidator<GetRetailerByIdQuery>
{
    public GetRetailerByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Retailer Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Retailer Id must be greater than 0.");
    }
}

