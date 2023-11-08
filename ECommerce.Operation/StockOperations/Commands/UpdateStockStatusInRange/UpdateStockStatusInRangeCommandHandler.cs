using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStockStatusInRange;

public class UpdateStockStatusInRangeCommandHandler : IRequestHandler<UpdateStockStatusInRangeCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateStockStatusInRangeCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateStockStatusInRangeCommand request, CancellationToken cancellationToken)
    {


        foreach (var i in request.Model.ProductsToUpdateStock)
        {


            var entity = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.ProductId == i.Key, cancellationToken);
            if (entity == null)
            {
                return new ApiResponse("Product" + i.Key + " not found!");
            }


            entity.StockStatus = (Base.Stock.StockStatus)i.Value;
            entity.UpdateDate = DateTime.UtcNow;
            //entity.UpdateUserId= 

        }


        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}





