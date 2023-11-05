using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.AddressOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ECommerce.Operation.AddressOperations.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, ApiResponse<AddressResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateAddressCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<AddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {

        var existingUser = await dbContext.Set<User>().FirstOrDefaultAsync(x=> x.Id == request.Model.UserId , cancellationToken);

        if (existingUser == null)
        {
            return new ApiResponse<AddressResponse>("Invalid operation : You must insert an address for a existing user." );

        }

        Address mapped = mapper.Map<Address>(request.Model);

        var entity = await dbContext.Set<Address>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<AddressResponse>(entity.Entity);
        return new ApiResponse<AddressResponse>(response);
    }

}

