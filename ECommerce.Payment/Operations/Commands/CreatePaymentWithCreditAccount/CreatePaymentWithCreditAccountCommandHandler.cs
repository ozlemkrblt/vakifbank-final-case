using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;

namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithCreditAccount;

public class CreatePaymentWithCreditAccountCommandHandler : IRequestHandler<CreatePaymentWithCreditAccountCommand, ApiResponse<PaymentResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreatePaymentWithCreditAccountCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<PaymentResponse>> Handle(CreatePaymentWithCreditAccountCommand request,  CancellationToken cancellationToken)
    {
        OrderPayment mapped = mapper.Map<OrderPayment>(request.Model);
 
        if (mapped.CreditAccount.ExpenseLimit < request.Model.PaymentAmount)
        {
            mapped.PaymentStatus = Base.PaymentStatus.Cancelled;
            return new ApiResponse<PaymentResponse>("Insufficient CreditAccount limit!");
        }
        if (mapped.CreditAccount.Balance < request.Model.PaymentAmount)
        {
            mapped.PaymentStatus = Base.PaymentStatus.Cancelled;
            return new ApiResponse<PaymentResponse>("Insufficient CreditAccount balance!");
        }

        mapped.PaymentDate = DateTime.UtcNow;
        mapped.InsertDate = DateTime.UtcNow;
        mapped.CreditAccount.Balance -= request.Model.PaymentAmount;
        mapped.PaymentStatus = Base.PaymentStatus.Approved;

        var entity = await dbContext.Set<OrderPayment>().AddAsync(mapped, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<PaymentResponse>(entity.Entity);
        return new ApiResponse<PaymentResponse>(response);

    }
    }


    

