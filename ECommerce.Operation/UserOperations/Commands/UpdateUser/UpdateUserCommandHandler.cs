using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.UserOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.UserOperations.Commands.UpdateUser;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateUserCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateOrderCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.Name = request.Model.Name;
        entity.LastName = request.Model.LastName;
        entity.UpdateDate = DateTime.UtcNow;
        //entity.UpdateUserId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

