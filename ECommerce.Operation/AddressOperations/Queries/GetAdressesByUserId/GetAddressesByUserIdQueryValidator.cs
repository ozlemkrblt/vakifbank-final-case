using ECommerce.Operation.AddressOperations.Cqrs;
using FluentValidation;


namespace ECommerce.Operation.AddressOperations.Queries.GetAdressesByUserId
{
    public class GetAddressesByUserIdQueryValidator : AbstractValidator<GetAddressesByUserIdQuery>
    {
        public GetAddressesByUserIdQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
