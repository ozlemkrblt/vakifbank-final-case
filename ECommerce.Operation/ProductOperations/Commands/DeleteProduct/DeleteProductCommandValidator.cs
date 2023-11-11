using ECommerce.Operation.ProductOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ProductOperations.Commands.DeleteProduct;
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Product Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
