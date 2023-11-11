using MediatR;
using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using ECommerce.Payment.Operations.Cqrs;
using ECommerce.Payment.Domain;

namespace ECommerce.Payment.Operations.Queries.GetPaymentDetails;
public class GetCreditAccountByRetailerIdQueryHandler : IRequestHandler<GetPaymentByOrderIdQuery, ApiResponse<PaymentResponse>>
{
    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetCreditAccountByRetailerIdQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }



    public async Task<ApiResponse<PaymentResponse>> Handle(GetPaymentByOrderIdQuery request,
      CancellationToken cancellationToken)
    {
        OrderPayment? Payment = await dbContext.Set<OrderPayment>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (Payment == null)
        {
            return new ApiResponse<PaymentResponse>("Record not found!");
        }

        PaymentResponse mapped = mapper.Map<PaymentResponse>(Payment);
        return new ApiResponse<PaymentResponse>(mapped);
    }
}

