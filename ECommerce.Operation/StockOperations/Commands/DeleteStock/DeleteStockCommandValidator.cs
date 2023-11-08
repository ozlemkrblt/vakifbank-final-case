using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Commands.DeleteStock;
public class DeleteStockCommandValidator : AbstractValidator< DeleteStockCommand>
{
    public DeleteStockCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Stock Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Stock Id must be greater than 0.");
    }
}

