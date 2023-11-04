using ECommerce.Operation.ProductOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ProductOperations.Queries.GetProductDetails;
public class GetRetailerByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponse>>
    {
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetRetailerByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIdQuery request,
      CancellationToken cancellationToken)
    {
        Product? Product = await dbContext.Set<Product>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Product == null)
        {
            return new ApiResponse<ProductResponse>("Record not found!");
        }

        ProductResponse mapped = mapper.Map<ProductResponse>(Product);
        return new ApiResponse<ProductResponse>(mapped);
    }
}

