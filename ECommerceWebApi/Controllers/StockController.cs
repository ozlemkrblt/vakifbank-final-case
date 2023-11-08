using ECommerce.Base.Response;
using ECommerce.Operation.StockOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private IMediator mediator;

    public StockController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<StockResponse>>> GetAll()
    {
        var operation = new GetAllStocksQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<StockResponse>> Get(int id)
    {
        var operation = new GetStockByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("Stocks")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<StockResponse>>> GetStockInRange(List<int> ids)
    {
        var operation = new GetStocksInRangeQuery(ids);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpGet("Product/{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<StockResponse>> GetByProductId(int id)
    {
        var operation = new GetStockByProductIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<StockResponse>> Post([FromBody] StockRequest request)
    {
        var operation = new CreateStockCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] StockRequest request)
    {
        var operation = new UpdateStockCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPut("StockValues/{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> PutStockValuesInRange([FromBody] StockRequest request)
    {
        var operation = new UpdateStockValueInRangeCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("MaxStocks/{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> PutMaxStocksInRange(int i, [FromBody] StockRequest request)
    {
        var operation = new UpdateMaxStockInRangeCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("StockStatuses/{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put( [FromBody] StockRequest request)
    {
        var operation = new UpdateStockStatusInRangeCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteStockCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}