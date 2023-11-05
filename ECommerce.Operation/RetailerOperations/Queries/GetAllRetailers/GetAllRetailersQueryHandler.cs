using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RetailerOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.RetailerOperations.Queries.GetRetailerDetails;
public class GetAllRetailersQueryHandler : IRequestHandler<GetAllRetailersQuery, ApiResponse<List<RetailerResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllRetailersQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<RetailerResponse>>> Handle(GetAllRetailersQuery request,
        CancellationToken cancellationToken)
    {
        List<Retailer> list = await dbContext.Set<Retailer>()
            .ToListAsync(cancellationToken);

        List<RetailerResponse> mapped = mapper.Map<List<RetailerResponse>>(list);
        return new ApiResponse<List<RetailerResponse>>(mapped);
    }

}
