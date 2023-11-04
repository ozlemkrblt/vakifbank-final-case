using ECommerce.Base.Response;
using ECommerce.Operation.RoleOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("vk/api/v1/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private IMediator mediator;

    public RoleController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<RoleResponse>>> GetAll()
    {
        var operation = new GetAllRolesQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse<RoleResponse>> Get(int id)
    {
        var operation = new GetRoleByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse<RoleResponse>> Post([FromBody] RoleRequest request)
    {
        var operation = new CreateRoleCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] RoleRequest request)
    {
        var operation = new UpdateRoleCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteRoleCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}