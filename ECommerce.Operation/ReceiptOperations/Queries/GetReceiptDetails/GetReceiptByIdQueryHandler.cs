using ECommerce.Operation.ReceiptOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ReceiptOperations.Queries.GetReceiptDetails;
public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ApiResponse<ReceiptResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetReceiptByIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<ReceiptResponse>> Handle(GetReceiptByIdQuery request,
      CancellationToken cancellationToken)
    {
        Receipt? Receipt = await dbContext.Set<Receipt>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Receipt == null)
        {
            return new ApiResponse<ReceiptResponse>("Record not found!");
        }

        ReceiptResponse mapped = mapper.Map<ReceiptResponse>(Receipt);
        return new ApiResponse<ReceiptResponse>(mapped);
    }
}

