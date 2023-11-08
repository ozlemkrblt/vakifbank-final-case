using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Queries.GetStocksInRange;

    public class GetStocksInRangeQueryValidator : AbstractValidator<GetStocksInRangeQuery>
    {
    public GetStocksInRangeQueryValidator()
    {
        RuleForEach(query => query.Ids).NotEmpty().WithMessage("Stock Id is required")
            .GreaterThan(0).WithMessage("Stock Id cannot be a negative value.");
    }
    }

