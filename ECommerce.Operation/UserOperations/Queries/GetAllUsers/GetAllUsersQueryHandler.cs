using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.UserOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ECommerce.Operation.UserOperations.Queries.GetUserDetails;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllUsersQuery, ApiResponse<List<UserResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllProductsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
       List<User> list = await dbContext.Set<User>().Include(x => x.Addresses).ToListAsync(cancellationToken);

        List<UserResponse> mapped = mapper.Map<List<UserResponse>>(list);
        return new ApiResponse<List<UserResponse>>(mapped);
    }

}
