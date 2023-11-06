using ECommerce.Operation.UserOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.UserOperations.Queries.GetAllUsers;
public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
    }
}
