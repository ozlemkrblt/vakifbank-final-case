using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ReceiptOperations.Queries.GetReceiptDetails;
public class GetAllReceiptsQueryHandler : IRequestHandler<GetAllReceiptsQuery, ApiResponse<List<ReceiptResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllReceiptsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<ReceiptResponse>>> Handle(GetAllReceiptsQuery request,
        CancellationToken cancellationToken)
    {
        List<Receipt> list = await dbContext.Set<Receipt>()
            .ToListAsync(cancellationToken);

        List<ReceiptResponse> mapped = mapper.Map<List<ReceiptResponse>>(list);
        return new ApiResponse<List<ReceiptResponse>>(mapped);
    }

}
