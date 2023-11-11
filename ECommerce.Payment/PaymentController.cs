using ECommerce.Base.Response;
using ECommerce.Payment.Base;
using ECommerce.Payment.Operations.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private IMediator mediator;

    public PaymentController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<PaymentResponse>>> GetAll()
    {
        var operation = new GetAllPaymentsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<PaymentResponse>> Get(int id)
    {
        var operation = new GetPaymentByOrderIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost("")]
    public async Task<ApiResponse<PaymentResponse>> Post([FromBody] PaymentRequest request)
    {
        switch (request.PaymentType)
        {
            case PaymentType.Card:
                var paymentWithCardCommand = new CreatePaymentWithCardCommand(request);
                return await mediator.Send(paymentWithCardCommand);
                break;
            case PaymentType.CreditAccount:
                var paymentWithCreditAccountCommand = new CreatePaymentWithCreditAccountCommand(request);
                var result1 = await mediator.Send(paymentWithCreditAccountCommand);
                return result1;
                break;
            default:
                var paymentWithEFTorTransferCommand = new CreatePaymentWithEFTorTransferCommand(request);
                var result2 = await mediator.Send(paymentWithEFTorTransferCommand);
                return result2;
                break;
        }


    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] PaymentRequest request)
    {
        var operation = new UpdatePaymentCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeletePaymentCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}

