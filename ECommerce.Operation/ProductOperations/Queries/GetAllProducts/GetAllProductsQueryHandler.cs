using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ProductOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ProductOperations.Queries.GetProductDetails;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<List<ProductResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllProductsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        List<Product> list = await dbContext.Set<Product>()
            .ToListAsync(cancellationToken);

        List<ProductResponse> mapped = mapper.Map<List<ProductResponse>>(list);
        return new ApiResponse<List<ProductResponse>>(mapped);
    }

}
