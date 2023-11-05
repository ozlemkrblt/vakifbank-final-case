using MediatR;
using ECommerce.Base.Response;
using ECommerce.Schema;


namespace ECommerce.Operation.AddressOperations.Cqrs;

   
    public record CreateAddressCommand(AddressRequest Model) : IRequest<ApiResponse<AddressResponse>>;
    public record UpdateAddressCommand(AddressRequest Model, int Id) : IRequest<ApiResponse>;
    public record DeleteAddressCommand(int Id) : IRequest<ApiResponse>;
    public record GetAllAddressesQuery() : IRequest<ApiResponse<List<AddressResponse>>>;
    public record GetAddressByIdQuery(int Id) : IRequest<ApiResponse<AddressResponse>>;

    public record GetAddressesByUserIdQuery(int UserId) : IRequest<ApiResponse<List<AddressResponse>>>;

