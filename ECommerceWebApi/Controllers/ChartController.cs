using EasyNetQ;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.OrderItemOperations.Cqrs;
using ECommerce.Operation.OrderItemOperations.Queries.GetAllOrderItemsByOrder;
using ECommerce.Operation.OrderOperations.Commands.CreateOrder;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private IMediator mediator;


    public ChartController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet("{id}")]
    [Authorize(Roles = "retailer")]
    public async Task<ApiResponse<OrderResponse>> GetOrder(int id)
    {
        var operation = new GetOrderByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("Retailer/Orders/{id}")]
    [Authorize(Roles = "retailer")]
    public async Task<ApiResponse<List<OrderResponse>>> GetAllUserOrders(int id)
    {
        var operation = new GetOrdersByRetailerIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "retailer")]
    public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest request)
    {
        var operation = new CreateOrderCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "retailer")]
    public async Task<ApiResponse> Put(int id, [FromBody] OrderRequest request)
    {
        var operation = new UpdateOrderCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "retailer")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteOrderCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}