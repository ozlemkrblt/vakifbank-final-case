using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.TokenOperations.Cqrs;

   
    public record CreateTokenCommand(TokenRequest Model) : IRequest<ApiResponse<TokenResponse>>;



