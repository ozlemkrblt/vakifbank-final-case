using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Queries.GetStockByProduct;
    public class GetStockByProductIdQueryHandler : IRequestHandler<GetStockByProductIdQuery, ApiResponse<StockResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetStockByProductIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<StockResponse>> Handle(GetStockByProductIdQuery request,CancellationToken cancellationToken)
    {
        Stock? Stock = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Stock == null)
        {
            return new ApiResponse<StockResponse>("Record not found!");
        }

        StockResponse mapped = mapper.Map<StockResponse>(Stock);
        return new ApiResponse<StockResponse>(mapped);
    }
}

