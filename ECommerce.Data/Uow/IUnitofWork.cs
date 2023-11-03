using ECommerce.Data.Domain;
using ECommerce.Data.Repository;


namespace ECommerce.Data.Uow;

public interface IUnitofWork
{
    void Complete();
    void CompleteTransaction();


    IGenericRepository<Address> AddressRepository { get; }
    IGenericRepository<Admin> AdminRepository { get; }
    IGenericRepository<Message> MessageRepository { get; }
    IGenericRepository<Order> OrderRepository { get; }
    IGenericRepository<OrderItem> OrderItemRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<Receipt> ReceiptRepository { get; }

    IGenericRepository<ReceiptInfo> ReceiptInfoRepository { get; }
    IGenericRepository<Retailer> RetailerRepository { get; }

    IGenericRepository<Role> RoleRepository { get; }
    IGenericRepository<User> UserRepository { get; }
}

