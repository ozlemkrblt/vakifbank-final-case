using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RetailerOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.RetailerOperations.Commands.UpdateRetailer;

/*public class UpdateRetailerCommandHandler : IRequestHandler<UpdateRetailerCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateRetailerCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateRetailerCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Retailer>().Include(r => r.ReceiptInfos).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        //ALl the related update operations are done within the UserCommandHandler. 
        //entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateRetailerId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

*/