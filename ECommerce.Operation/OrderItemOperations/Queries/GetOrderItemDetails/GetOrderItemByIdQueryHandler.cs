using ECommerce.Operation.OrderItemOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderItemOperations.Queries.GetOrderItemDetails;
public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, ApiResponse<OrderItemResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetOrderItemByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<OrderItemResponse>> Handle(GetOrderItemByIdQuery request,
      CancellationToken cancellationToken)
    {
        OrderItem? OrderItem = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (OrderItem == null)
        {
            return new ApiResponse<OrderItemResponse>("Record not found!");
        }

        OrderItemResponse mapped = mapper.Map<OrderItemResponse>(OrderItem);
        return new ApiResponse<OrderItemResponse>(mapped);
    }
}

