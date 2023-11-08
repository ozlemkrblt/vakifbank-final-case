using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;
using static ECommerce.Schema.StockRequest;

namespace ECommerce.Operation.StockOperations.Cqrs;

   
    public record CreateStockCommand(StockRequest Model) : IRequest<ApiResponse<StockResponse>>;
    public record UpdateStockCommand(StockRequest Model, int Id) : IRequest<ApiResponse>;
    public record UpdateStockValueInRangeCommand(StockRequest Model) : IRequest<ApiResponse>;
    public record UpdateStockStatusInRangeCommand(StockRequest Model) : IRequest<ApiResponse>;
    public record UpdateMaxStockInRangeCommand(StockRequest Model) : IRequest<ApiResponse>;
    public record DeleteStockCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllStocksQuery() : IRequest<ApiResponse<List<StockResponse>>>;
    public record GetStockByIdQuery(int Id) : IRequest<ApiResponse<StockResponse>>;
    public record GetStockByProductIdQuery(int Id) : IRequest<ApiResponse<StockResponse>>;
    public record GetStocksInRangeQuery(List<int> Ids) : IRequest<ApiResponse<List<StockResponse>>>;

    


