using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrderDetails;
public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");
    }
}

