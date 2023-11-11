using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;

namespace ECommerce.Payment.Operations.Commands.UpdateCreditAccount;
public class UpdateCreditAccountCommandValidator : AbstractValidator<UpdateCreditAccountCommand>
{
    public UpdateCreditAccountCommandValidator()
    {
        RuleFor(command => command.Model.RetailerId).NotNull().WithMessage("Retailer Id must be given.");
        RuleFor(command => command.Model.RetailerId).GreaterThan(0).WithMessage("Retailer Id must be greater than 0.");

        RuleFor(command => command.Model.ExpenseLimit).NotNull().WithMessage("Expense Limit is required.");
        RuleFor(command => command.Model.ExpenseLimit).GreaterThan(0).WithMessage("Expense Limit must be greater than 0.");

        RuleFor(command => command.Model.CurrencyCode).NotNull().WithMessage("Currency Code is required.");

    }
}

