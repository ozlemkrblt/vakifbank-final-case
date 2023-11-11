using ECommerce.Base.Response;
using ECommerce.Payment.Operations.Cqrs;
using ECommerce.Payment.Schema.CreditAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class CreditAccountController : ControllerBase
{
    private IMediator mediator;

    public CreditAccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<CreditAccountResponse>>> GetAll()
    {
        var operation = new GetAllCreditAccountsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreditAccountResponse>> Get(int id)
    {
        var operation = new GetCreditAccountByRetailerIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost("")]
    public async Task<ApiResponse<CreditAccountResponse>> Post([FromBody] CreditAccountRequest request)
    {

        var operation = new CreateCreditAccountCommand(request);
        var result = await mediator.Send(operation);
        return result;

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreditAccountResponse>> Put(int id, [FromBody] CreditAccountRequest request)
    {
        var operation = new UpdateCreditAccountCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteCreditAccountCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}

