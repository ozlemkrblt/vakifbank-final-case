using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.ProductOperations.Cqrs;

   
    public record CreateProductCommand(ProductRequest Model) : IRequest<ApiResponse<ProductResponse>>;
    public record UpdateProductCommand(ProductRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteProductCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllProductsQuery() : IRequest<ApiResponse<List<ProductResponse>>>;
    public record GetProductByIdQuery(int Id) : IRequest<ApiResponse<ProductResponse>>;


