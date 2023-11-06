

using ECommerce.Operation.UserOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.UserOperations.Commands.UpdateUser;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Role Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Role Id must be greater than 0.");
       

        RuleFor(command => command.Model.Name).NotNull().WithMessage("Name is required.");
        RuleFor(x => x.Model.Name).MaximumLength(20).WithMessage("Name length max value is 20.");

        RuleFor(command => command.Model.LastName).NotNull().WithMessage("Last name is required");
        RuleFor(x => x.Model.LastName).MaximumLength(20).WithMessage("LastName length max value is 20.");

        RuleFor(command => command.Model.RoleId).NotNull().WithMessage("Role Id is required.");
        RuleFor(command => command.Model.RoleId).GreaterThan(0).WithMessage("Role Id must be greater than 0.");
    }
}

