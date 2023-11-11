using ECommerce.Operation.OrderItemOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderItemOperations.Queries.GetAllOrderItemsByOrder;
public class GetAllOrderItemsByOrderQueryValidator : AbstractValidator<GetAllOrderItemsByOrderQuery>
{
    public GetAllOrderItemsByOrderQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");
    }
}

