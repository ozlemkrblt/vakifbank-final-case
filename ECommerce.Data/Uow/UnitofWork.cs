

using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Uow;

public class UnitofWork : IUnitofWork
{
    private readonly ECommerceDbContext dbContext;
    public UnitofWork(ECommerceDbContext dbContext)
    {
        this.dbContext = dbContext;

        AddressRepository = new GenericRepository<Address>(dbContext);
        AdminRepository = new GenericRepository<Admin>(dbContext);
        MessageRepository = new GenericRepository<Message>(dbContext);
        OrderRepository = new GenericRepository<Order>(dbContext);
        OrderItemRepository = new GenericRepository<OrderItem>(dbContext);
        ProductRepository = new GenericRepository<Product>(dbContext);
        ReceiptRepository = new GenericRepository<Receipt>(dbContext);
        RetailerRepository = new GenericRepository<Retailer>(dbContext);
        RoleRepository = new GenericRepository<Role>(dbContext);
        UserRepository = new GenericRepository<User>(dbContext);
    }

    public IGenericRepository<Address> AddressRepository { get; private set; }
    public IGenericRepository<Admin> AdminRepository { get; private set; }
    public IGenericRepository<Message> MessageRepository { get; private set; }
    public IGenericRepository<Order> OrderRepository { get; private set; }
    public IGenericRepository<OrderItem> OrderItemRepository { get; private set; }
    public IGenericRepository<Product> ProductRepository { get; private set; }
    public IGenericRepository<Receipt> ReceiptRepository { get; private set; }
    public IGenericRepository<Retailer> RetailerRepository { get; private set; }
    public IGenericRepository<Role> RoleRepository { get; private set; }
    public IGenericRepository<User> UserRepository { get; }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteTransaction()
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.Error("CompleteTransactionError", ex);
            }
        }
    }
}

