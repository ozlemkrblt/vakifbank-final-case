using ECommerce.Operation.ReceiptOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.ReceiptOperations.Queries.GetReceiptDetails;
public class GetReceiptInfoByReceiptIdQueryValidator : AbstractValidator<GetReceiptInfoByReceiptIdQuery>
{
    public GetReceiptInfoByReceiptIdQueryValidator() {
        RuleFor(command => command.Id).NotNull().WithMessage("Receipt Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Receipt Id must be greater than 0.");
    }
}

