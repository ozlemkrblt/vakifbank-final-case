using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Queries.GetAllCreditAccounts;
public class GetAllCreditAccountsQueryValidator : AbstractValidator<GetAllPaymentsQuery>
{
    public GetAllCreditAccountsQueryValidator()
    {
    }
}
