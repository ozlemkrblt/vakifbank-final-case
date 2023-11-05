using ECommerce.Base.Response;
using ECommerce.Operation.OrderOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("vk/api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IMediator mediator;

    public OrderController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<OrderResponse>>> GetAll()
    {
        var operation = new GetAllOrdersQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<OrderResponse>> Get(int id)
    {
        var operation = new GetOrderByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest request)
    {
        var operation = new CreateOrderCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] OrderRequest request)
    {
        var operation = new UpdateOrderCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteOrderCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}