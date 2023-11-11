using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.OrderOperations.Cqrs;

   
    public record CreateOrderCommand(OrderRequest Model) : IRequest<ApiResponse<OrderResponse>>;
    public record UpdateOrderCommand(OrderRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllOrdersQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<OrderResponse>>;
    public record GetOrdersByRetailerIdQuery(int Id) : IRequest<ApiResponse<List<OrderResponse>>>;

