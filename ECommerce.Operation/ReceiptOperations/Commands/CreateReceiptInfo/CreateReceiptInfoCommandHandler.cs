using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.ReceiptOperations.Commands.CreateReceiptInfo;

public class CreateReceiptInfoCommandHandler : IRequestHandler<CreateReceiptInfoCommand, ApiResponse<ReceiptInfoResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateReceiptInfoCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<ReceiptInfoResponse>> Handle(CreateReceiptInfoCommand request, CancellationToken cancellationToken)
    {
        ReceiptInfo mapped = mapper.Map<ReceiptInfo>(request.Model);
        mapped.InsertDate = DateTime.UtcNow;
        var entity = await dbContext.Set<ReceiptInfo>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<ReceiptInfoResponse>(entity.Entity);
        return new ApiResponse<ReceiptInfoResponse>(response);

    }

}

