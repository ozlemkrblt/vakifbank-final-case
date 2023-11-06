
using ECommerce.Operation.RoleOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RoleOperations.Commands.DeleteRole;
public class DeleteRoleCommandValidator : AbstractValidator< DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Role Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Role Id must be greater than 0.");
    }
}

