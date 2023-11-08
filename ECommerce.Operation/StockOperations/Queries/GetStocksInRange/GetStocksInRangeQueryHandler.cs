using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Queries.GetStocksInRange;
public class GetStocksInRangeQueryHandler : IRequestHandler<GetStocksInRangeQuery, ApiResponse<List<StockResponse>>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetStocksInRangeQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<StockResponse>>> Handle(GetStocksInRangeQuery request,
      CancellationToken cancellationToken)
    {
        var stockResponses = new List<StockResponse>();


        foreach (int id in request.Ids)
        {

            Stock? Stock = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (Stock != null)
            {

                StockResponse mapped = mapper.Map<StockResponse>(Stock);
                stockResponses.Add(mapped);
            }
        }

        if (!stockResponses.Any())
        {
            return new ApiResponse<List<StockResponse>>("Records not found!");

        }

        return new ApiResponse<List<StockResponse>>(stockResponses);

    }

}


