using MediatR;
using ECommerce.Base.Response;
using ECommerce.Payment.Schema.CreditAccount;

namespace ECommerce.Payment.Operations.Cqrs;


public record CreateCreditAccountCommand(CreditAccountRequest Model) : IRequest<ApiResponse<CreditAccountResponse>>;
public record UpdateCreditAccountCommand(CreditAccountRequest Model, int id) : IRequest<ApiResponse<CreditAccountResponse>>;
public record DeleteCreditAccountCommand(int id) : IRequest<ApiResponse>;
public record GetAllCreditAccountsQuery() : IRequest<ApiResponse<List<CreditAccountResponse>>>;
public record GetCreditAccountByRetailerIdQuery(int Id) : IRequest<ApiResponse<CreditAccountResponse>>;


