using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RoleOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.RoleOperations.Queries.GetAllRoles;
public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, ApiResponse<List<RoleResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllRolesQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<RoleResponse>>> Handle(GetAllRolesQuery request,
        CancellationToken cancellationToken)
    {
        List<Role> list = await dbContext.Set<Role>()
            .ToListAsync(cancellationToken);

        List<RoleResponse> mapped = mapper.Map<List<RoleResponse>>(list);
        return new ApiResponse<List<RoleResponse>>(mapped);
    }

}
