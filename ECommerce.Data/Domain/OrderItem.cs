using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;
public class OrderItem : BaseModel
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public string ProductName { get; set; } 
    public string ProductDescription { get; set; }  
    public double ProductPrice { get; set; }    
    public int ProductAmount { get; set; }

}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    { }
}