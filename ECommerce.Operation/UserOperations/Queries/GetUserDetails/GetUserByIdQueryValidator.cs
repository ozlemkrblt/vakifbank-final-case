using ECommerce.Operation.UserOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.UserOperations.Queries.GetUserById;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("User Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("User Id must be greater than 0.");

    }
}
