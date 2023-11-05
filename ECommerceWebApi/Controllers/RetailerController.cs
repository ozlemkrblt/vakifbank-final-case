using ECommerce.Base.Response;
using ECommerce.Operation.RetailerOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("vk/api/v1/[controller]")]
[ApiController]
public class RetailerController : ControllerBase
{
    private IMediator mediator;

    public RetailerController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    //[Authorize(Retailers = "admin")]
    public async Task<ApiResponse<List<RetailerResponse>>> GetAll()
    {
        var operation = new GetAllRetailersQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    //[Authorize(Retailers = "admin")]
    public async Task<ApiResponse<RetailerResponse>> Get(int id)
    {
        var operation = new GetRetailerByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    //[Authorize(Retailers = "admin")]
    public async Task<ApiResponse<RetailerResponse>> Post([FromBody] RetailerRequest request)
    {
        var operation = new CreateRetailerCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

 /*   [HttpPut("{id}")]
    //[Authorize(Retailers = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] RetailerRequest request)
    {
        var operation = new UpdateRetailerCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }
 */

    [HttpDelete("{id}")]
    //[Authorize(Retailers = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteRetailerCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}