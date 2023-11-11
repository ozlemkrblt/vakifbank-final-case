using ECommerce.Operation.AddressOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.AddressOperations.Commands.DeleteAddress;

public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Product Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");

    }
}