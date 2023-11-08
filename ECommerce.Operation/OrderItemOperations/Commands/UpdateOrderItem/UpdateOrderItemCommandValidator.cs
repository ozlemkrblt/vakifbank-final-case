using Azure.Core;
using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ECommerce.Operation.OrderOperations.Commands.UpdateOrder;
public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderItemCommandValidator()
    {
        RuleFor(command => command.Id).NotNull().WithMessage("Order Id must be given.");
        RuleFor(command => command.Id).GreaterThan(0).WithMessage("Order Id must be greater than 0.");

        RuleFor(command => command.Model.Amount).GreaterThanOrEqualTo(0).WithMessage("Amount must be 0 or greater than 0.");
        RuleFor(command => command.Model.Amount).Must(BeValidDoubleFormat).WithMessage("Amount should be in format 'xx.xx'");
        RuleFor(command => command.Model.PaymentStatus).IsInEnum().WithMessage("Please give a valid payment status.");

        RuleFor(command => command.Model.ReceiptId).GreaterThan(0).WithMessage("Receipt Id must be greater than 0.");
        RuleFor(command => command.Model.RetailerId).NotNull().WithMessage("Retailer Id must be given.");
        RuleFor(command => command.Model.RetailerId).GreaterThan(0).WithMessage("Retailer Id must be greater than 0.");


    }
    private bool BeValidDoubleFormat(double amount)
    {

        return Regex.IsMatch(amount.ToString(), @"^\d+\.\d{2}$");
    }

}


