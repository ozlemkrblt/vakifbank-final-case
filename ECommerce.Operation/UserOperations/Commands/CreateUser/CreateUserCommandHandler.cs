using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.UserOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.UserOperations.Commands.CreateUser;

public class CreateAddressCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateAddressCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User mapped = mapper.Map<User>(request.Model);

        var entity = await dbContext.Set<User>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<UserResponse>(entity.Entity);
        return new ApiResponse<UserResponse>(response);
    }

}

