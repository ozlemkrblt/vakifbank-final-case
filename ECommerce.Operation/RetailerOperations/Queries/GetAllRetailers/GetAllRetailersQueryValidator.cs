using ECommerce.Operation.RetailerOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.RetailerOperations.Queries.GetAllRetailers;
public class GetAllRetailersQueryValidator : AbstractValidator<GetAllRetailersQuery>
{
    public GetAllRetailersQueryValidator()
    {
    }
}

