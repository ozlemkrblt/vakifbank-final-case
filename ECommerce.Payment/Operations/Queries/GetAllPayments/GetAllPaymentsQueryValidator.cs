using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Queries.GetAllPayments;
public class GetAllCreditAccountsQueryValidator : AbstractValidator<GetAllPaymentsQuery>
{
    public GetAllCreditAccountsQueryValidator()
    {
    }
}
