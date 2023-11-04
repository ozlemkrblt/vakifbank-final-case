using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.RoleOperations.Cqrs;

   
    public record CreateRoleCommand(RoleRequest Model) : IRequest<ApiResponse<RoleResponse>>;
    public record UpdateRoleCommand(RoleRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteRoleCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllRolesQuery() : IRequest<ApiResponse<List<RoleResponse>>>;
    public record GetRoleByIdQuery(int Id) : IRequest<ApiResponse<RoleResponse>>;


