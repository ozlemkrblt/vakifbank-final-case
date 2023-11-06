
using ECommerce.Operation.AddressOperations.Cqrs;
using FluentValidation;


namespace ECommerce.Operation.AddressOperations.Queries.GetAddressDetails
{
    public class GetAllAddressesQueryValidator : AbstractValidator<GetAllAddressesQueryValidator>
    {
        public GetAllAddressesQueryValidator()
        {
        }
    }
}
