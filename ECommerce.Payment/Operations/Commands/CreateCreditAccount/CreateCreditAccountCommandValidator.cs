using ECommerce.Payment.Operations.Cqrs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ECommerce.Payment.Operations.Commands.CreateCreditAccount
{
    public class CreateCreditAccountCommandValidator : AbstractValidator<CreateCreditAccountCommand>
    {
        public CreateCreditAccountCommandValidator() {
            RuleFor(command => command.Model.RetailerId).NotNull().WithMessage("Retailer Id must be given.");
            RuleFor(command => command.Model.RetailerId).GreaterThan(0).WithMessage("Retailer Id must be greater than 0.");

            RuleFor(command => command.Model.ExpenseLimit).NotNull().WithMessage("Expense Limit is required.");
            RuleFor(command => command.Model.ExpenseLimit).GreaterThan(0).WithMessage("Expense Limit must be greater than 0.");
            
            RuleFor(command => command.Model.CurrencyCode).NotNull().WithMessage("Currency Code is required.");


            
        }

    }
}
