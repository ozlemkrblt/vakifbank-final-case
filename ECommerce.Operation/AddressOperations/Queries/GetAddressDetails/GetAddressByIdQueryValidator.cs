using ECommerce.Operation.AddressOperations.Cqrs;
using FluentValidation;


namespace ECommerce.Operation.AddressOperations.Queries.GetAddressDetails
{
    public class GetAddressByIdQueryValidator : AbstractValidator<GetAddressByIdQuery>
    {
        public GetAddressByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty().GreaterThan(0);
        }
    }
}
