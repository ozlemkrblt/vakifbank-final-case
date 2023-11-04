using AutoMapper;
using Azure;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.RoleOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.Operation.RoleOperations.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateRoleCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Role>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.Name = request.Model.Name;
        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateUserId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

