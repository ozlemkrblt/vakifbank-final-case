using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using ECommerce.Payment.Base;
using MediatR;
using ECommerce.Base.Enums;

namespace ECommerce.Operation.OrderOperations.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public CreateOrderCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                Order mapped = mapper.Map<Order>(request.Model);
                mapped.OrderDate = DateTime.UtcNow;

                Random random = new Random();
                int orderNo = random.Next(10000000, 99999999);
                mapped.OrderNo = orderNo;

                foreach (OrderItem item in mapped.Items)
                {
                    if (item.Product.Stock.StockValue < item.ProductQuantity)
                    {
                        transaction.Rollback();
                        return new ApiResponse<OrderResponse>("This product is not in the stock. Please order another time or change the order.");
                    }
                    else
                    {
                        mapped.Amount += (item.Product.Price * item.ProductQuantity);
                        item.Product.Stock.StockValue--;
                        mapped.OrderStatus = OrderStatus.WaitingForCompanyApproval;
                    }
                }

                //mapped.PaymentStatus = PaymentStatus.Approved;
                var entity = await dbContext.Set<Order>().AddAsync(mapped, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);

                transaction.Commit();


                var response = mapper.Map<OrderResponse>(entity.Entity);
                return new ApiResponse<OrderResponse>(response);
            }
            catch (Exception ex)
            {
                // Handle the exception
                transaction.Rollback();
                return new ApiResponse<OrderResponse>($"An error occurred: {ex.Message}");
            }
        }



    }

}

