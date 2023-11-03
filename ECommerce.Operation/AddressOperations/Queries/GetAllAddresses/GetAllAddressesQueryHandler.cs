using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.AddressOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.AddressOperations.Queries.GetAddressDetails;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllAddressesQuery, ApiResponse<List<AddressResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllProductsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AddressResponse>>> Handle(GetAllAddressesQuery request,
        CancellationToken cancellationToken)
    {
        List<Address> list = await dbContext.Set<Address>()
            .ToListAsync(cancellationToken);

        List<AddressResponse> mapped = mapper.Map<List<AddressResponse>>(list);
        return new ApiResponse<List<AddressResponse>>(mapped);
    }

}
