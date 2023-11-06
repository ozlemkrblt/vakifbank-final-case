using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ReceiptOperations.Commands.UpdateReceiptInfo;

public class UpdateReceiptInfoCommandHandler : IRequestHandler<UpdateReceiptInfoCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateReceiptInfoCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateReceiptInfoCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<ReceiptInfo>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }

        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateReceiptId= 
        entity.AddressId = request.Model.AddressId;
        entity.MersisNo = request.Model.MersisNo;
        entity.RetailerTaxNumber = request.Model.RetailerTaxNumber;
        entity.CompanyName = request.Model.CompanyName; 


        dbContext.Entry(entity).Property(x => x.RetailerId).IsModified = false;
        dbContext.Entry(entity).Property(x => x.ReceiptId).IsModified = false;
        dbContext.Entry(entity).Property(x => x.Receipt).IsModified = false;
        dbContext.Entry(entity).Property(x => x.Address).IsModified = false;


        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();

    }

}

