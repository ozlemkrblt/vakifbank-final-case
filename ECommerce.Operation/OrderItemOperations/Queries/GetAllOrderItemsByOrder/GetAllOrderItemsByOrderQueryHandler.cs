using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderItemOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderItemOperations.Queries.GetAllOrderItemsByOrder;
public class GetAllOrderItemsByOrderQueryHandler : IRequestHandler<GetAllOrderItemsByOrderQuery, ApiResponse<List<OrderItemResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllOrderItemsByOrderQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<OrderItemResponse>>> Handle(GetAllOrderItemsByOrderQuery request,
        CancellationToken cancellationToken)
    {
        var result = new List<OrderItemResponse>();

        var orderItems = await dbContext.Set<OrderItem>()
            .Where(item => item.OrderId == request.Id)
            .ToListAsync(cancellationToken);

        result = mapper.Map<List<OrderItemResponse>>(orderItems);

        if (!result.Any())
        {
            return new ApiResponse<List<OrderItemResponse>>("Order items not found!");
        }

        return new ApiResponse<List<OrderItemResponse>>(result);

    }
}
