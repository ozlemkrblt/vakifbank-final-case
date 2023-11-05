using ECommerce.Base.Response;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("vk/api/v1/[controller]")]
[ApiController]
public class ReceiptController : ControllerBase
{
    private IMediator mediator;

    public ReceiptController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<ReceiptResponse>>> GetAll()
    {
        var operation = new GetAllReceiptsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptResponse>> Get(int id)
    {
        var operation = new GetReceiptByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptResponse>> Post([FromBody] ReceiptRequest request)
    {
        var operation = new CreateReceiptCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    /*[HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] ReceiptRequest request)
    {
        var operation = new UpdateReceiptCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }
    */
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteReceiptCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}