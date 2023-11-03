using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.AddressOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.AddressOperations.Commands.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateAddressCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Address>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.AddressLine1 = request.Model.AddressLine1;
        entity.AddressLine2 = request.Model.AddressLine2;
        entity.City=request.Model.City;
        entity.District=request.Model.District;
        entity.District = request.Model.PostalCode;
        entity.UserId = request.Model.UserId;   
        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateAddressId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

