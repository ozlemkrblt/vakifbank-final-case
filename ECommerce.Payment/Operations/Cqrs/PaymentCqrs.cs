using MediatR;
using ECommerce.Base.Response;


namespace ECommerce.Payment.Operations.Cqrs;


public record CreatePaymentWithCardCommand(PaymentRequest Model) : IRequest<ApiResponse<PaymentResponse>>;
public record CreatePaymentWithCreditAccountCommand(PaymentRequest Model) : IRequest<ApiResponse<PaymentResponse>>;
public record CreatePaymentWithEFTorTransferCommand(PaymentRequest Model) : IRequest<ApiResponse<PaymentResponse>>;
public record UpdatePaymentCommand(PaymentRequest Model, int Id) : IRequest<ApiResponse>;
public record DeletePaymentCommand(int Id) : IRequest<ApiResponse>;
public record GetAllPaymentsQuery() : IRequest<ApiResponse<List<PaymentResponse>>>;
public record GetPaymentByOrderIdQuery(int Id) : IRequest<ApiResponse<PaymentResponse>>;


