using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.StockOperations.Commands.CreateStock;

public class CreateStockCommandValidator :AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(command => command.Model.StockValue).NotEmpty().WithMessage("Stock value must be given.");
        RuleFor(command => command.Model.StockValue).GreaterThanOrEqualTo(0).WithMessage("Stock value cannot be a negative integer.");
        RuleFor(command => command.Model.StockValue).LessThanOrEqualTo(command => command.Model.MaxStock).WithMessage("Stock value cannot be more than maximum stock.");

        RuleFor(command => command.Model.MaxStock).GreaterThanOrEqualTo(0).WithMessage("Stock value cannot be a negative integer.");
        RuleFor(command => command.Model.MaxStock).NotEmpty().WithMessage("Stock value must be given.");
        
        RuleFor(command => command.Model.ProductId).NotEmpty().WithMessage("Product Id must be given.");
        RuleFor(command => command.Model.ProductId).GreaterThanOrEqualTo(0).WithMessage("Stock value cannot be a negative integer.");
        
        RuleFor(command => command.Model.StockStatus).GreaterThanOrEqualTo(0).WithMessage("Stock status cannot be a negative integer.");
        RuleFor(command => command.Model.StockStatus).IsInEnum().WithMessage("Please provide a valid StockStatus.");

    }

}

