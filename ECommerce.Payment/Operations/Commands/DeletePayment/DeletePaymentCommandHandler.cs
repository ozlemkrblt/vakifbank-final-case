using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Base;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Payment.Operations.Commands.DeletePayment;

public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public DeletePaymentCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<OrderPayment>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        if (entity.PaymentStatus == PaymentStatus.Cancelled || entity.PaymentStatus == PaymentStatus.NotApproved)
        {
            entity.IsActive = false;
            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
        else
        {
            return new ApiResponse("Payment status is : " + entity.PaymentStatus + "Please try after the final result.");
        }


    }

}

