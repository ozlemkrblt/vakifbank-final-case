

using ECommerce.Operation.ProductOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ProductOperations.Commands.CreateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {

        RuleFor(command => command.Id).NotNull().WithMessage("Product Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Product Name is required.");
        RuleFor(x => x.Model.Price).NotEmpty().WithMessage("Price is required.");
        RuleFor(x => x.Model.Price).GreaterThan(0).WithMessage("Price should be 0 or higher than 0");


        RuleFor(x => x.Model.Stock).NotEmpty().WithMessage("Stock Information is required.");
        RuleFor(x => x.Model.Price).GreaterThanOrEqualTo(0).WithMessage("Stock value should be 0 or higher than 0");
        RuleFor(x => x.Model.Description).MaximumLength(100).WithMessage("Description should be maximum 100 characters.");

    }
}

