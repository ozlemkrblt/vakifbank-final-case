/* Receipts shouldn't be updated 


using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ReceiptOperations.Commands.UpdateReceipt;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateReceiptCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateRoleCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Receipt>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }

        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateReceiptId= 

        dbContext.Entry(entity).Property(x => x.ReceiptNo).IsModified = false;
        dbContext.Entry(entity).Property(x => x.ReceiptDate).IsModified = false;
        dbContext.Entry(entity).Property(x => x.RetailerId).IsModified = false;
        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

*/