using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.UpdateStock;

public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateStockCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.StockStatus = (Base.Stock.StockStatus)request.Model.StockStatus;
        entity.StockValue = request.Model.StockValue;
        entity.MaxStock = request.Model.MaxStock;
        entity.ProductId = request.Model.ProductId;

        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateUserId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

