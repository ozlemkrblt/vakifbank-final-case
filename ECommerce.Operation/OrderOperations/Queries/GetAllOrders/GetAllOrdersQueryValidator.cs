using ECommerce.Operation.OrderOperations.Cqrs;
using FluentValidation;

namespace ECommerce.Operation.OrderOperations.Queries.GetAllOrders;
public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
{
    public GetAllOrdersQueryValidator() { }
}

