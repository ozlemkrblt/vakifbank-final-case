

using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;

public class Order : BaseModel
{

    public int OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public double PaymentStatus { get; set; }


    public int UserId { get; set; }  // one order can belong to one user
    public User User { get; set; }

    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();  // one order can contain many orderitems
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    { }
}