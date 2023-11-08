using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Queries.GetStockDetails;
public class GetStockByIdQueryValidator : AbstractValidator<GetStockByIdQuery>
{
    public GetStockByIdQueryValidator()
    {
        RuleFor(query => query.Id).NotNull().WithMessage("Stock Id must be given.");
        RuleFor(query => query.Id).GreaterThan(0).WithMessage("Stock Id must be greater than 0.");

    }
}

