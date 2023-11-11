using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ECommerce.Operation.OrderOperations.Queries.GetOrdersByRetailerId;

public class GetOrdersByRetailerIdQueryValidator : AbstractValidator<GetOrdersByRetailerIdQuery>
{
    public GetOrdersByRetailerIdQueryValidator()
    {
        RuleFor(query => query.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(query => query.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");
        }

}

