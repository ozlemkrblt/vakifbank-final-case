using ECommerce.Operation.OrderOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrderDetails;
public class GetProductByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetProductByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<OrderResponse>> Handle(GetOrderByIdQuery request,
      CancellationToken cancellationToken)
    {
        Order? Order = await dbContext.Set<Order>()
            .Include(x => x.Items)
            .Include(x => x.Retailer)
            //receipt not included in the interface
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Order == null)
        {
            return new ApiResponse<OrderResponse>("Record not found!");
        }

        OrderResponse mapped = mapper.Map<OrderResponse>(Order);
        return new ApiResponse<OrderResponse>(mapped);
    }
}

