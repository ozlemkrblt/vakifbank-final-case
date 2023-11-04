using ECommerce.Operation.RetailerOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.RetailerOperations.Queries.GetRetailerDetails;
public class GetRetailerByIdQueryHandler : IRequestHandler<GetRetailerByIdQuery, ApiResponse<RetailerResponse>>
    {
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetRetailerByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<RetailerResponse>> Handle(GetRetailerByIdQuery request,
      CancellationToken cancellationToken)
    {
        Retailer? Retailer = await dbContext.Set<Retailer>()
            .Include(x => x.ReceiptInfos)
            .Include(x => x.Addresses)
            .Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Retailer == null)
        {
            return new ApiResponse<RetailerResponse>("Record not found!");
        }

        RetailerResponse mapped = mapper.Map<RetailerResponse>(Retailer);
        return new ApiResponse<RetailerResponse>(mapped);
    }
}

