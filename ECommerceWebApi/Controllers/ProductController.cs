﻿using ECommerce.Base.Response;
using ECommerce.Operation.ProductOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers;


[Route("os/api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<ProductResponse>>> GetAll()
    {
        var operation = new GetAllProductsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ProductResponse>> Get(int id)
    {
        var operation = new GetProductByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest request)
    {
        var operation = new CreateProductCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public async Task<ApiResponse> Put(int id, [FromBody] ProductRequest request)
    {
        var operation = new UpdateProductCommand(request, id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteProductCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}