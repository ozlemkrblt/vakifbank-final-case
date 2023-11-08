using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStockValueInRange;
public class UpdateMaxStockInRangeCommandValidator : AbstractValidator<UpdateStockValueInRangeCommand>
{
    private readonly ECommerceDbContext _dbContext;
    public UpdateMaxStockInRangeCommandValidator(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;


        RuleFor(command => command.Model.ProductsToUpdateStock)
              .NotEmpty().WithMessage("ProductsToUpdateStockStatus dictionary cannot be empty.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Keys)
                .NotEmpty().WithMessage("Product Id cannot be empty.")
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Values)
                .GreaterThanOrEqualTo(0).WithMessage($"Product Stock status cannot be a negative integer.")
                .IsInEnum().WithMessage("Please provide a valid StockStatus.");


        RuleForEach(command => command.Model.ProductsToUpdateStock.Values)
                .NotEmpty().WithMessage("Stock value must be given.")
                .GreaterThanOrEqualTo(0).WithMessage("Stock value cannot be a negative integer.")
                .IsInEnum().WithMessage("Please provide a valid StockStatus.");
                 //.MustAsync(async (productId, cancellationToken) => await BeWithinMaxStock(productId, cancellationToken))
                //.WithMessage("Stock value cannot be more than maximum stock.");
    }


  /*  private async Task<bool> BeWithinMaxStock(int productId, CancellationToken cancellationToken)
    {
        // Get the MaxStock value for the current ProductId from the database
        int maxStock = await _dbContext.Set<Product>
            .Where(p => p.Id == productId)
            .Select(p => p.Stock.MaxValue)
            .FirstOrDefaultAsync(cancellationToken);

        // Compare the current stock value with MaxStock
        int stockValue = context.ParentContext.PropertyValue[productId];
        return stockValue <= maxStock;
    }*/
}

