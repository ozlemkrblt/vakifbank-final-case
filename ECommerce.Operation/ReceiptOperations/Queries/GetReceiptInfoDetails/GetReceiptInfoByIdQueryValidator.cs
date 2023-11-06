using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptIdOperations.Queries.GetReceiptDetails;
public class GetReceiptInfoByIdQueryValidator : AbstractValidator<GetReceiptInfoByIdQuery>
{
    public GetReceiptInfoByIdQueryValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("ReceiptInfo Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("ReceiptInfo Id must be greater than 0.");
    }
}

