using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.RetailerOperations.Cqrs;

   
    public record CreateRetailerCommand(RetailerRequest Model) : IRequest<ApiResponse<RetailerResponse>>;
    //public record UpdateRetailerCommand(RetailerRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteRetailerCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllRetailersQuery() : IRequest<ApiResponse<List<RetailerResponse>>>;
    public record GetRetailerByIdQuery(int Id) : IRequest<ApiResponse<RetailerResponse>>;


