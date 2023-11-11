using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using MediatR;
using ECommerce.Payment.Schema.CreditAccount;
using ECommerce.Payment.Operations.Cqrs;

namespace ECommerce.Payment.Operations.Commands.CreateCreditAccount;
public class CreateCreditAccountCommandHandler : IRequestHandler< CreateCreditAccountCommand, ApiResponse<CreditAccountResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateCreditAccountCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<CreditAccountResponse>> Handle(CreateCreditAccountCommand request, CancellationToken cancellationToken)
    {
        CreditAccount mapped = mapper.Map<CreditAccount>(request.Model);


        mapped.OpenDate = DateTime.UtcNow;
        Random random = new Random();
        mapped.AccountNo = random.Next(10000000, 99999999);
        mapped.InsertDate = DateTime.UtcNow;

        var entity = await dbContext.Set<CreditAccount>().AddAsync(mapped, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<CreditAccountResponse>(entity.Entity);
        return new ApiResponse<CreditAccountResponse>(response);

    }
}