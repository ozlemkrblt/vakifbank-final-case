using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrdersByRetailerId;
public class GetOrdersByRetailerIdQueryHandler : IRequestHandler<GetOrdersByRetailerIdQuery, ApiResponse<List<OrderResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetOrdersByRetailerIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<OrderResponse>>> Handle(GetOrdersByRetailerIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = new List<OrderResponse>();


        var orders = await dbContext.Set<Retailer>().Include(x => x.Orders)
            .ToListAsync(cancellationToken);

        result = mapper.Map<List<OrderResponse>>(orders);

        if (!result.Any())
        {
            return new ApiResponse<List<OrderResponse>>("Orders not found!");
        }

        return new ApiResponse<List<OrderResponse>>(result);

    }
}
