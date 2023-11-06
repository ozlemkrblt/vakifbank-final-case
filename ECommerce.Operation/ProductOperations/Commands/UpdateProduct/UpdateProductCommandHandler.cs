using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.ProductOperations.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Operation.ProductOperations.Commands.UpdateProduct;

public class UpdateRetailerCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse>
{

    private readonly ECommerceDbContext dbContext;
    private readonly IMapper mapper;


    public UpdateRetailerCommandHandler(ECommerceDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse("Record not found!");
        }
        entity.Price = request.Model.Price;
        entity.Name=request.Model.Name;
        entity.Stock= request.Model.Stock;
        entity.Description=request.Model.Description;
        entity.UpdateDate = DateTime.UtcNow;

        //entity.UpdateProductId= 

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }

}

