using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderItemOperations.Cqrs;
using ECommerce.Schema;
using ECommerce.Payment.Base;
using MediatR;
using ECommerce.Base.Enums;

namespace ECommerce.Operation.OrderItemOperations.Commands.CreateOrderItem;

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ApiResponse<OrderItemResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateOrderItemCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<OrderItemResponse>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        OrderItem mapped = mapper.Map<OrderItem>(request.Model);
        if (mapped.Product == null)
        {
            return new ApiResponse<OrderItemResponse>("Product not found! ");

        }else if (mapped.Product.Stock.StockStatus != (StockStatus)1)
        {
            return new ApiResponse<OrderItemResponse>("Product is out of stock. ");
        }
        else
        {
            var entity = await dbContext.Set<OrderItem>().AddAsync(mapped, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<OrderItemResponse>(entity.Entity);
            return new ApiResponse<OrderItemResponse>(response);
        }

       


    }

}

