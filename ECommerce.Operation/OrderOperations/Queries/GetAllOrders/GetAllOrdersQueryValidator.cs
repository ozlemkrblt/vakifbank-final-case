using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrderDetails;
public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
{
    public GetAllOrdersQueryValidator() { }
}

