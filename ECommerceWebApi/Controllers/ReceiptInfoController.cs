using ECommerce.Base.Response;
using ECommerce.Operation.ReceiptOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class ReceiptInfoController : ControllerBase
{
    private IMediator mediator;

    public ReceiptInfoController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptInfoResponse>> Get(int id)
    {
        var operation = new GetReceiptInfoByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/User/{userid}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptInfoResponse>> GetByUserId(int userid)
    {
        var operation = new GetReceiptInfoByUserIdQuery(userid);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/Receipt/{receiptid}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptInfoResponse>> GetByReceiptId(int receiptid)
    {
        var operation = new GetReceiptInfoByReceiptIdQuery(receiptid);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ReceiptInfoResponse>> Post([FromBody] ReceiptInfoRequest request)
    {
        var operation = new CreateReceiptInfoCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] ReceiptInfoRequest request)
    {
        var operation = new UpdateReceiptInfoCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }
    

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteReceiptInfoCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}