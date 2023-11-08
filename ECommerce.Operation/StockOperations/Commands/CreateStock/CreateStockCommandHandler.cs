using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.StockOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.StockOperations.Commands.CreateStock;

public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, ApiResponse<StockResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateStockCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<StockResponse>> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        Stock mapped = mapper.Map<Stock>(request.Model);
        mapped.InsertDate = DateTime.UtcNow;
        var entity = await dbContext.Set<Stock>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<StockResponse>(entity.Entity);
        return new ApiResponse<StockResponse>(response);

    }

}

