using ECommerce.Operation.RoleOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RoleOperations.Queries.GetRoleDetails;
public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Role Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Role Id must be greater than 0.");

    }
}

