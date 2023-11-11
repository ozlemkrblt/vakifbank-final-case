using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Commands.DeleteCreditAccount;
public class DeleteCreditAccountCommandValidator : AbstractValidator<DeleteCreditAccountCommand>
{
    public DeleteCreditAccountCommandValidator()
    {
        RuleFor(command => command.id).NotNull().WithMessage("Credit Account Id must be given.");
        RuleFor(command => command.id).GreaterThan(0).WithMessage("Credit Account Id must be greater than 0.");
    }
}

