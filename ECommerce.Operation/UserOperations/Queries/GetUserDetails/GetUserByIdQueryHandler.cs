using ECommerce.Operation.UserOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.UserOperations.Queries.GetUserDetails;
public class GetProductByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetProductByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<UserResponse>> Handle(GetUserByIdQuery request,
      CancellationToken cancellationToken)
    {
        User? user = await dbContext.Set<User>()
            .Include(x => x.Addresses)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user == null)
        {
            return new ApiResponse<UserResponse>("Record not found!");
        }

        UserResponse mapped = mapper.Map<UserResponse>(user);
        return new ApiResponse<UserResponse>(mapped);
    }
}

