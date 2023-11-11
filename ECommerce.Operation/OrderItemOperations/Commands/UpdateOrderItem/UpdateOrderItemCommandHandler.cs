using AutoMapper;
using Azure;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderItemOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.OrderItemOperations.Commands.UpdateOrderItem;

public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateOrderItemCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.ProductQuantity = request.Model.ProductQuantity;
        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateOrderItemId= 

        dbContext.Entry(entity).Property(x => x.Order).IsModified = false;
        dbContext.Entry(entity).Property(x => x.OrderId).IsModified = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

