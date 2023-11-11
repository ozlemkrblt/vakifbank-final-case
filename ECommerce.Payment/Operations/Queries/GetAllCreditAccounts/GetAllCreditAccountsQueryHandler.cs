using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Payment.Domain;
using ECommerce.Payment.Operations.Cqrs;
using ECommerce.Payment.Schema.CreditAccount;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Payment.Operations.Queries.GetAllCreditAccounts;
public class GetAllCreditAccountsQueryHandler : IRequestHandler<GetAllCreditAccountsQuery, ApiResponse<List<CreditAccountResponse>>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;
    public GetAllCreditAccountsQueryHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<List<CreditAccountResponse>>> Handle(GetAllCreditAccountsQuery request,
        CancellationToken cancellationToken)
    {
       List<CreditAccount> list = await dbContext.Set<CreditAccount>().ToListAsync(cancellationToken);

        List<CreditAccountResponse> mapped = mapper.Map<List<CreditAccountResponse>>(list);
        return new ApiResponse<List<CreditAccountResponse>>(mapped);
    }

}
