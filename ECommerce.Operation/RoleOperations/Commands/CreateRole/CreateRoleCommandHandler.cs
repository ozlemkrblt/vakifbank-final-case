using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RoleOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.RoleOperations.Commands.CreateRole;

public class CreateTokenCommandHandler : IRequestHandler<CreateRoleCommand, ApiResponse<RoleResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateTokenCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<RoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Role mapped = mapper.Map<Role>(request.Model);
        mapped.InsertDate = DateTime.UtcNow;
        var entity = await dbContext.Set<Role>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<RoleResponse>(entity.Entity);
        return new ApiResponse<RoleResponse>(response);

    }

}

