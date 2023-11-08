using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrderDetails;
public class GetOrderItemByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderItemByIdQueryValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Item Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Item Id must be greater than 0.");
    }
}

