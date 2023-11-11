using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Payment.Operations.Commands.CreatePayment;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdatePaymentCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<OrderPayment>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.PaymentStatus = request.Model.PaymentStatus;
        entity.Transfer.Status = request.Model.transfer.Status;
        entity.EFT.Status = request.Model.eft.Status;
        entity.UpdateDate = DateTime.UtcNow;
        entity.PaymentType = request.Model.PaymentType;

        //entity.UpdateUserId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

