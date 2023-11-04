using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderOperations.Queries.GetOrderDetails;
public class GetAllReceiptsQueryHandler : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<OrderResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllReceiptsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        List<Order> list = await dbContext.Set<Order>()
            .Include(x => x.Items.Take(3))
            .ToListAsync(cancellationToken);

        List<OrderResponse> mapped = mapper.Map<List<OrderResponse>>(list);
        return new ApiResponse<List<OrderResponse>>(mapped);
    }

}
