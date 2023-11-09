using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.UserOperations.Cqrs;

   
    public record CreateUserCommand(UserRequest Model) : IRequest<ApiResponse<UserResponse>>;
    public record UpdateUserCommand(UserRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllUsersQuery() : IRequest<ApiResponse<List<UserResponse>>>;
    public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;


