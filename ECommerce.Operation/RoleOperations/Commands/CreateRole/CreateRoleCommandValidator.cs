

using ECommerce.Operation.RoleOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RoleOperations.Commands.CreateRole;

public class CreateRoleCommandValidator :AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(command => command.Model.Name).NotEmpty().WithMessage("Role name must be given.");
        RuleFor(command => command.Model.Name).MaximumLength(20).WithMessage("Role name length should be maximum 20 characters.");

    }
}

