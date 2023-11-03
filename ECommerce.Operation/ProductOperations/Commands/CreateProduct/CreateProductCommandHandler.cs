using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ProductOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.ProductOperations.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateProductCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product mapped = mapper.Map<Product>(request.Model);

        var entity = await dbContext.Set<Product>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        var response = mapper.Map<ProductResponse>(entity.Entity);
        return new ApiResponse<ProductResponse>(response);
    }

}

