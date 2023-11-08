using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;


namespace ECommerce.Operation.StockOperations.Queries.GetAllStocks;
public class GetAllStocksQueryValidator : AbstractValidator<GetAllStocksQuery>
{
    public GetAllStocksQueryValidator() { }
}

