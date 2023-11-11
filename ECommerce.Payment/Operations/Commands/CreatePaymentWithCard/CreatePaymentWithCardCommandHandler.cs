using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Base;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;

namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithEFT;

public class CreatePaymentWithCardCommandHandler : IRequestHandler<CreatePaymentWithCardCommand, ApiResponse<PaymentResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreatePaymentWithCardCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<PaymentResponse>> Handle(CreatePaymentWithCardCommand request, CancellationToken cancellationToken)
    {
        OrderPayment mapped = mapper.Map<OrderPayment>(request.Model);

        if (mapped.Card.ExpiryDate < DateTime.UtcNow)
        {
            mapped.PaymentStatus = Base.PaymentStatus.OnHold;
            return new ApiResponse<PaymentResponse>("Invalid card informations!");
        }
        if (mapped.Card.ExpenseLimit < mapped.Order.Amount)
        {
            mapped.PaymentStatus = Base.PaymentStatus.NotApproved;
            return new ApiResponse<PaymentResponse>("Insufficient card limit!");
        }

        mapped.PaymentDate = DateTime.UtcNow;
        mapped.InsertDate = DateTime.UtcNow;
        mapped.PaymentStatus = PaymentStatus.Pending;
        var entity = await dbContext.Set<OrderPayment>().AddAsync(mapped, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<PaymentResponse>(entity.Entity);
        return new ApiResponse<PaymentResponse>(response);

    }
}




