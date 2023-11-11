using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Payment.Operations.Commands.UpdateCreditAccount;

public class UpdateCreditAccountCommandHandler : IRequestHandler<UpdateCreditAccountCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateCreditAccountCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateCreditAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<CreditAccount>().FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.ExpenseLimit = request.Model.ExpenseLimit;
        entity.CurrencyCode = request.Model.CurrencyCode;
        entity.UpdateDate = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

