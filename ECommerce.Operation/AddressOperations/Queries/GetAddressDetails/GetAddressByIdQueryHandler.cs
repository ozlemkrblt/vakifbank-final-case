using ECommerce.Operation.AddressOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.AddressOperations.Queries.GetAddressDetails;
public class GetProductByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, ApiResponse<AddressResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetProductByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AddressResponse>> Handle(GetAddressByIdQuery request,
      CancellationToken cancellationToken)
    {
        Address? Address = await dbContext.Set<Address>()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Address == null)
        {
            return new ApiResponse<AddressResponse>("Record not found!");
        }

        AddressResponse mapped = mapper.Map<AddressResponse>(Address);
        return new ApiResponse<AddressResponse>(mapped);
    }
}

