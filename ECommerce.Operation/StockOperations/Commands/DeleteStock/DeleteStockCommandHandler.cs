using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.StockOperations.Commands.DeleteStock;

public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public DeleteStockCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Stock>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }

        entity.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

