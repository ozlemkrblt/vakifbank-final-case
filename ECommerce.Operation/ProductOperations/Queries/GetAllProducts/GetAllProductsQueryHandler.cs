using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ProductOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ECommerce.Operation.RetailerOperations.Queries.GetRetailerDetails;
using ECommerce.Operation.RetailerOperations.Cqrs;
using ECommerce.Data.Uow;

namespace ECommerce.Operation.ProductOperations.Queries.GetProductDetails;
public class GetAllRetailersQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<List<ProductResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;

    public GetAllRetailersQueryHandler(ECommerceDbContext dbContext, IMapper mapper, IMediator mediator)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
        string role = claims?.FirstOrDefault(x => x.Type.Equals("Role", StringComparison.OrdinalIgnoreCase))?.Value;


        if (role == "retailer ")
        {
            int id = claims?.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.OrdinalIgnoreCase))?.Value;

            UnitofWork unitofWork = new UnitofWork(dbContext);
            var retailer = unitofWork.RetailerRepository.Where(x => x.Id == id);
            var profitmargin = retailer.First().ProfitMargin;

            List<Product> list = await dbContext.Set<Product>()
                .ToListAsync(cancellationToken);


            foreach (Product p in list) {

                p.Price += (p.Price * profitmargin) / 100; 
            }


            List<ProductResponse> mapped = mapper.Map<List<ProductResponse>>(list);
            return new ApiResponse<List<ProductResponse>>(mapped);

        }
        else
        {
            List<Product> list = await dbContext.Set<Product>()
                .ToListAsync(cancellationToken);


            foreach (Product p in list)
            {

                p.Price += (p.Price * pMargin) / 100;
            }


            List<ProductResponse> mapped = mapper.Map<List<ProductResponse>>(list);
            return new ApiResponse<List<ProductResponse>>(mapped);
        }
    }

}
