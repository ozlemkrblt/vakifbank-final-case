using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.OrderItemOperations.Cqrs;

    public record CreateOrderItemCommand(OrderItemRequest Model) : IRequest<ApiResponse<OrderItemResponse>>;
    public record UpdateOrderItemCommand(OrderItemRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderItemCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllOrderItemsByOrderQuery(int Id) : IRequest<ApiResponse<List<OrderItemResponse>>>;
    public record GetOrderItemByIdQuery(int Id) : IRequest<ApiResponse<OrderItemResponse>>;


