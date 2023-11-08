using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStockValueInRange;

public class UpdateStockValueInRangeCommandHandler : IRequestHandler<UpdateStockValueInRangeCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateStockValueInRangeCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateStockValueInRangeCommand request, CancellationToken cancellationToken)
    {


        foreach (var i in request.Model.ProductsToUpdateStock) {


            var entity = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.ProductId == i.Key, cancellationToken);
            if (entity == null)
            {
                return new ApiResponse("Product" + i.Key + " not found!");
            }
     
            entity.StockValue = i.Value;
            entity.UpdateDate = DateTime.UtcNow;
            //entity.UpdateUserId= 

        }


        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

