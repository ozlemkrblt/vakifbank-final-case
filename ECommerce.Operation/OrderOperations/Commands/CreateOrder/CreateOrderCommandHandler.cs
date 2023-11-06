using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using ECommerce.Payment.Base;
using MediatR;

namespace ECommerce.Operation.OrderOperations.Commands.CreateOrder;

public class CreateReceiptCommandHandler : IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateReceiptCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order mapped = mapper.Map<Order>(request.Model);
        mapped.OrderDate = DateTime.UtcNow;

        Random random = new Random();
        int orderNo = random.Next(10000000, 99999999); // Generates a random number between 10000000 and 99999999

        mapped.OrderNo = orderNo;
        foreach (OrderItem item in mapped.Items){
            mapped.Amount += (item.Product.Price * item.ProductQuantity);
        }

        mapped.PaymentStatus = PaymentStatus.Approved;
        var entity = await dbContext.Set<Order>().AddAsync(mapped, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<OrderResponse>(entity.Entity);
        return new ApiResponse<OrderResponse>(response);

    }

}

