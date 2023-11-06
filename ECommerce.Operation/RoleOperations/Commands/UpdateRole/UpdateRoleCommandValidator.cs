using ECommerce.Operation.RoleOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RoleOperations.Commands.UpdateRole;
public class UpdateRoleCommandValidator: AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Role Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Role Id must be greater than 0.");
        RuleFor(command => command.Model.Name).NotEmpty().WithMessage("Role name must be given.");
        RuleFor(command => command.Model.Name).MaximumLength(20).WithMessage("Role name length should be maximum 20 characters.");
    }
}
