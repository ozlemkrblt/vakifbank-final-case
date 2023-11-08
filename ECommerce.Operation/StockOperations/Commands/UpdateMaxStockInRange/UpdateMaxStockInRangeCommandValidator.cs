using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Commands.UpdateMaxStockInRange;
public class UpdateMaxStockInRangeCommandValidator : AbstractValidator<UpdateMaxStockInRangeCommand>
{
    public UpdateMaxStockInRangeCommandValidator()
    {
        RuleFor(command => command.Model.ProductsToUpdateStock)
       .NotEmpty().WithMessage("ProductsToUpdateStockStatus dictionary cannot be empty.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Keys)
                .NotEmpty().WithMessage("Product Id cannot be empty.")
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Values)
                .GreaterThanOrEqualTo(0).WithMessage("Max stock cannot be a negative integer.")
                 .NotEmpty().WithMessage("Max stock must be given.");

    }
}

