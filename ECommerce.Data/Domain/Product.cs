using ECommerce.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Domain;
public class Product : BaseModel
{

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public List<OrderItem> Items { get; set; } // one product may have multiple orderitems 

}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        
    }
}