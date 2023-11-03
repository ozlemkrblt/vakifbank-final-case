using AutoMapper;
using Azure;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Operation.OrderOperations.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateOrderCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.ReceiptId = request.Model.ReceiptId;
        entity.PaymentStatus = request.Model.PaymentStatus;
        entity.Amount = request.Model.Amount;
        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateOrderId= 

        dbContext.Entry(entity).Property(x => x.OrderNo).IsModified = false;
        dbContext.Entry(entity).Property(x => x.OrderDate).IsModified = false;
        dbContext.Entry(entity).Property(x => x.RetailerId).IsModified = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

