using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStockStatusInRange;
public class UpdateStockStatusInRangeCommandValidator : AbstractValidator<UpdateStockStatusInRangeCommand>
{
    public UpdateStockStatusInRangeCommandValidator()
    {
        RuleFor(command => command.Model.ProductsToUpdateStock)
               .NotEmpty().WithMessage("ProductsToUpdateStockStatus dictionary cannot be empty.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Keys)
                .NotEmpty().WithMessage("Product Id cannot be empty.")
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Values)
                .GreaterThanOrEqualTo(0).WithMessage("Stock status cannot be a negative integer.")
                .IsInEnum().WithMessage("Please provide a valid StockStatus.");
    }
    



    }


