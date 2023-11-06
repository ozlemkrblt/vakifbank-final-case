﻿using ECommerce.Operation.AddressOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.AddressOperations.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {

            RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Model.AddressLine1).MaximumLength(30).WithMessage("Address Line 1 max length is 30.").NotEmpty().WithMessage("Address Line 1 is required.");
            RuleFor(x => x.Model.AddressLine2).MaximumLength(30).WithMessage("AddresLine length max value is 30.");
            RuleFor(x => x.Model.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Model.District).NotEmpty().WithMessage("District is required.");
            RuleFor(x => x.Model.PostalCode).Length(5).WithMessage("Postal Code should be 5 integer format.").NotEmpty().WithMessage("Postal Code is required.");
            RuleFor(x => x.Model.UserId).NotEmpty().WithMessage("Address must belong to a user.");


        }
    }
}
