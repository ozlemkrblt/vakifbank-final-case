using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.UserOperations.Queries.GetUserById;
public class GetCreditAccountByRetailerIdQueryValidator : AbstractValidator<GetPaymentByOrderIdQuery>
{
    public GetCreditAccountByRetailerIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");

    }
}
