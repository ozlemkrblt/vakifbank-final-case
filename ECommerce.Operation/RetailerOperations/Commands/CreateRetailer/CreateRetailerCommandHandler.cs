using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RetailerOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.RetailerOperations.Commands.CreateRetailer;

public class CreateRetailerCommandHandler : IRequestHandler<CreateRetailerCommand, ApiResponse<RetailerResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateRetailerCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<RetailerResponse>> Handle(CreateRetailerCommand request, CancellationToken cancellationToken)
    {
        Retailer mapped = mapper.Map<Retailer>(request.Model);
        mapped.InsertDate = DateTime.UtcNow;
        var entity = await dbContext.Set<Retailer>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        var response = mapper.Map<RetailerResponse>(entity.Entity);
        return new ApiResponse<RetailerResponse>(response);
    }

}

