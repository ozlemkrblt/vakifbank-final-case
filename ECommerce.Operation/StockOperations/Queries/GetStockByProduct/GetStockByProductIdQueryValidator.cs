using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Queries.GetStockByProduct;

public class GetStockByProductIdQueryValidator : AbstractValidator<GetStockByProductIdQuery>
{
    public GetStockByProductIdQueryValidator()
    {
        RuleFor(query => query.Id).NotNull().WithMessage("Product Id must be given.");
        RuleFor(query => query.Id).GreaterThan(0).WithMessage("Product Id must be greater than 0.");
    }
}

