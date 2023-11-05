using ECommerce.Base.Response;
using ECommerce.Operation.AddressOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("vk/api/v1/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private IMediator mediator;

    public AddressController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<AddressResponse>>> GetAll()
    {
        var operation = new GetAllAddressesQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<AddressResponse>> Get(int id)
    {
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{userid}")]
    [Authorize(Roles = "admin,retailer")]
    [HttpGet("/UserAdresses/{userid}")]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<AddressResponse>>> GetByUserId(int userid)
    {
        var operation = new GetAddressesByUserIdQuery(userid);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<AddressResponse>> Post([FromBody] AddressRequest request)
    {
        var operation = new CreateAddressCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] AddressRequest request)
    {
        var operation = new UpdateAddressCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}