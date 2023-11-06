using ECommerce.Operation.ProductOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ProductOperations.Queries.GetProductDetails;
public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Product Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}

