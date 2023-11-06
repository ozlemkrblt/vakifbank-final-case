using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;
using System.Text.RegularExpressions;
using ECommerce.Payment.Base;

namespace ECommerce.Operation.OrderOperations.Commands.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        //System-generated : 
        RuleFor(command => command.Model.OrderNo).GreaterThan(0).WithMessage("Order No must be greater than 0.");
        RuleFor(command => command.Model.OrderNo).Must(BeAValid8DigitNumber).WithMessage("OrderNo must be an 8-digit number.");

        RuleFor(command => command.Model.Amount).GreaterThanOrEqualTo(0).WithMessage("Amount must be 0 or greater than 0.");
        RuleFor(command => command.Model.Amount).Must(BeValidDoubleFormat).WithMessage("Amount should be in format 'xx.xx'");
        RuleFor(command => command.Model.PaymentStatus).IsInEnum().WithMessage("Please give a valid payment status.");

        RuleFor(command => command.Model.ReceiptId).GreaterThan(0).WithMessage("Receipt Id must be greater than 0.");
        RuleFor(command => command.Model.RetailerId).NotNull().WithMessage("Retailer Id must be given.");
        RuleFor(command => command.Model.RetailerId).GreaterThan(0).WithMessage("Retailer Id must be greater than 0.");
    }


    private bool BeAValid8DigitNumber(int orderNo)
    {
        return orderNo >= 10000000 && orderNo <= 99999999;
    }
    private bool BeValidDoubleFormat(double amount)
    {

        return Regex.IsMatch(amount.ToString(), @"^\d+\.\d{2}$");
    }
}

