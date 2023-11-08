using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Queries.GetAllStocks;
public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, ApiResponse<List<StockResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllStocksQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<StockResponse>>> Handle(GetAllStocksQuery request,
        CancellationToken cancellationToken)
    {
        List<Stock> list = await dbContext.Set<Stock>()
            .ToListAsync(cancellationToken);

        List<StockResponse> mapped = mapper.Map<List<StockResponse>>(list);
        return new ApiResponse<List<StockResponse>>(mapped);
    }

}
