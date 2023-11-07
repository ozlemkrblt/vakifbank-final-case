using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptIdOperations.Queries.GetReceiptDetails;
public class GetReceiptInfoByUserIdQueryValidator : AbstractValidator<GetReceiptInfoByUserIdQuery>
{
    public GetReceiptInfoByUserIdQueryValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("User Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("User Id must be greater than 0.");
    }
}

