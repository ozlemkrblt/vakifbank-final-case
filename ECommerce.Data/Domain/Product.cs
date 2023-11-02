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


}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        
    }
}