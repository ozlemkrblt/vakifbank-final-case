using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.ReceiptOperations.Cqrs;

   
    public record CreateReceiptCommand(ReceiptRequest Model) : IRequest<ApiResponse<ReceiptResponse>>;
   // public record UpdateReceiptCommand(ReceiptRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteReceiptCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllReceiptsQuery() : IRequest<ApiResponse<List<ReceiptResponse>>>;
    public record GetReceiptByIdQuery(int Id) : IRequest<ApiResponse<ReceiptResponse>>;


