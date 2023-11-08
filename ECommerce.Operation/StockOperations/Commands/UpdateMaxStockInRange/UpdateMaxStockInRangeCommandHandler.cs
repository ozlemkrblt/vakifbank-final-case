using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStockValueInRange;

public class UpdateMaxStockInRangeCommandHandler : IRequestHandler<UpdateMaxStockInRangeCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateMaxStockInRangeCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateMaxStockInRangeCommand request, CancellationToken cancellationToken)
    {


        foreach (var i in request.Model.ProductsToUpdateStock) {


            var entity = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.ProductId == i.Key, cancellationToken);
            if (entity == null)
            {
                return new ApiResponse("Product" + i.Key + " not found!");
            }


            entity.MaxStock =  i.Value;
            entity.UpdateDate = DateTime.UtcNow;

        }

      

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

