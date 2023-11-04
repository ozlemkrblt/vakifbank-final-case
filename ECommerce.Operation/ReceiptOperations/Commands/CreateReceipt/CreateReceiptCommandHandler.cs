﻿using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;

namespace ECommerce.Operation.ReceiptOperations.Commands.CreateReceipt;

public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, ApiResponse<ReceiptResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateReceiptCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<ReceiptResponse>> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        Receipt mapped = mapper.Map<Receipt>(request.Model);
        mapped.InsertDate = DateTime.UtcNow;
        var entity = await dbContext.Set<Receipt>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<ReceiptResponse>(entity.Entity);
        return new ApiResponse<ReceiptResponse>(response);

    }

}
