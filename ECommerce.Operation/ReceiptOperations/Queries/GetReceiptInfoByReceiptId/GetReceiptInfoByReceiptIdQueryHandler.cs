using ECommerce.Operation.ReceiptOperations.Cqrs;
using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ReceiptOperations.Queries.GetReceiptInfoByReceiptId;
public class GetReceiptInfoByReceiptIdQueryHandler : IRequestHandler<GetReceiptInfoByReceiptIdQuery, ApiResponse<ReceiptInfoResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetReceiptInfoByReceiptIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<ReceiptInfoResponse>> Handle(GetReceiptInfoByReceiptIdQuery request,
      CancellationToken cancellationToken)
    {
        ReceiptInfo? ReceiptInfo = await dbContext.Set<ReceiptInfo>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (ReceiptInfo == null)
        {
            return new ApiResponse<ReceiptInfoResponse>("Record not found!");
        }

        ReceiptInfoResponse mapped = mapper.Map<ReceiptInfoResponse>(ReceiptInfo);
        return new ApiResponse<ReceiptInfoResponse>(mapped);
    }
}

