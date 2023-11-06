using ECommerce.Operation.RoleOperations.Cqrs;
using FluentValidation;


namespace ECommerce.Operation.RoleOperations.Queries.GetAllRoles;
public class GetAllRolesQueryValidator : AbstractValidator<GetAllRolesQuery>
{
    public GetAllRolesQueryValidator() { }
}

