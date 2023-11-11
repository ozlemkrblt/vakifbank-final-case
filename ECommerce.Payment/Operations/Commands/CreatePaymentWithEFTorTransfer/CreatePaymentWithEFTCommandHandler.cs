using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Base;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;

namespace ECommerce.Payment.Operations.Commands.CreatePaymentWithEFTorTransfer;

public class CreatePaymentWithTransferCommandHandler : IRequestHandler<CreatePaymentWithEFTorTransferCommand, ApiResponse<PaymentResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreatePaymentWithTransferCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<PaymentResponse>> Handle(CreatePaymentWithEFTorTransferCommand request,  CancellationToken cancellationToken)
    {
        if (request.Model.PaymentType == PaymentType.EFT)
        {
            OrderPayment mapped = mapper.Map<OrderPayment>(request.Model);
            mapped.EFT.Status = (int)(TransactionStatus.Pending);
            if (request.Model.eft.TransactionDate > DateTime.UtcNow)
            {
                mapped.EFT.Status = (int)TransactionStatus.OnFuture;
            }

            if (request.Model.eft.Amount < 1000)
            {
                mapped.EFT.ChargeAmount = 2.5;
            }
            else if (request.Model.eft.Amount > 1000)
            {
                mapped.EFT.ChargeAmount = 5;
            }
            else
            {
                mapped.EFT.ChargeAmount = 10;
            }

            mapped.EFT.Amount -= mapped.EFT.ChargeAmount;

            if (request.Model.eft.Amount != mapped.Order.Amount)
            {
                mapped.PaymentStatus = PaymentStatus.OnHold;
            }

            mapped.PaymentDate = DateTime.UtcNow;
            mapped.InsertDate = DateTime.UtcNow;
            mapped.PaymentStatus = PaymentStatus.Pending;
            var entity = await dbContext.Set<OrderPayment>().AddAsync(mapped, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<PaymentResponse>(entity.Entity);
            return new ApiResponse<PaymentResponse>(response);
        }
        else
        {
            OrderPayment mapped = mapper.Map<OrderPayment>(request.Model);
            mapped.Transfer.Status = (int)(TransactionStatus.Pending);
            if (request.Model.transfer.TransactionDate > DateTime.UtcNow)
            {
                mapped.Transfer.Status = (int)TransactionStatus.OnFuture;
            }

            if (request.Model.transfer.Amount < 1000)
            {
                mapped.Transfer.ChargeAmount = 2.5;
            }
            else if (request.Model.transfer.Amount > 1000)
            {
                mapped.Transfer.ChargeAmount = 5;
            }
            else
            {
                mapped.Transfer.ChargeAmount = 10;
            }

            mapped.Transfer.Amount -= mapped.Transfer.ChargeAmount;

            if (request.Model.transfer.Amount != mapped.Order.Amount)
            {
                mapped.PaymentStatus = PaymentStatus.OnHold;
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
    }


    

