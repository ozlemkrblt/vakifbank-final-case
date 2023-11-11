using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Payment.Operations.Queries.GetAllPayments;
public class GetGetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, ApiResponse<List<PaymentResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetGetAllPaymentsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<PaymentResponse>>> Handle(GetAllPaymentsQuery request,
        CancellationToken cancellationToken)
    {
       List<OrderPayment> list = await dbContext.Set<OrderPayment>().ToListAsync(cancellationToken);

        List<PaymentResponse> mapped = mapper.Map<List<PaymentResponse>>(list);
        return new ApiResponse<List<PaymentResponse>>(mapped);
    }

}
