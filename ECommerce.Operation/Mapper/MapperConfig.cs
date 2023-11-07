using AutoMapper;
using ECommerce.Data.Domain;
using ECommerce.Schema;

namespace ECommerce.Operation.Mapper;
public class MapperConfig : Profile
{
    public MapperConfig()
    {

        CreateMap<AddressRequest, Address>();
        CreateMap<Address, AddressResponse>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.User != null ? src.User.UserName : ""));

        CreateMap<AdminRequest, Admin>();
        CreateMap<Admin, AdminResponse>();

        CreateMap<MessageRequest, Message>();
        CreateMap<Message, MessageResponse>()
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.UserName));

        CreateMap<OrderRequest, Order>();
        CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.RetailerUserName,
                opt => opt.MapFrom(src => src.Retailer.UserName))
        .ForMember(dest => dest.PaymentStatus,
                opt => opt.MapFrom(src => src.PaymentStatus.ToString()));

        CreateMap<OrderItemRequest, OrderItem>();
        CreateMap<OrderItem, OrderItemResponse>()
            .ForMember(dest => dest.OrderNo, opt => opt.MapFrom(src => src.Order.OrderNo))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Product.Price * src.ProductQuantity));

        CreateMap<ProductRequest, Product>();
        CreateMap<Product,ProductResponse>();

        CreateMap<ReceiptRequest, Receipt>();
        CreateMap<Receipt, ReceiptResponse>()
            .ForMember(dest => dest.OrderNo, opt => opt.MapFrom(src => src.Order.OrderNo))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Order.Amount))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
            .ForMember(dest => dest.ReceiptInfo, opt => opt.MapFrom(src => src.ReceiptInfo.ToString())) ;

        CreateMap<ReceiptInfoRequest, ReceiptInfo>();
        CreateMap<ReceiptInfo, ReceiptInfoResponse>();

        CreateMap<RetailerRequest, Retailer>();
        CreateMap<Retailer, RetailerResponse>();

        CreateMap<RoleRequest, Role>();
        CreateMap<Role, RoleResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.RoleName,
                opt => opt.MapFrom(src => src.Role.Name));

    }




}

