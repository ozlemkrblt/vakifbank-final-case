using ECommerce.Operation.RoleOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.RoleOperations.Queries.GetRoleDetails;
public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, ApiResponse<RoleResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetRoleByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<RoleResponse>> Handle(GetRoleByIdQuery request,
      CancellationToken cancellationToken)
    {
        Role? Role = await dbContext.Set<Role>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Role == null)
        {
            return new ApiResponse<RoleResponse>("Record not found!");
        }

        RoleResponse mapped = mapper.Map<RoleResponse>(Role);
        return new ApiResponse<RoleResponse>(mapped);
    }
}

