using ECommerce.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Product", Schema = "dbo")]
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
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.Price).IsRequired(true).HasPrecision(10,2);
        builder.Property(x => x.Stock).IsRequired(true).HasMaxLength(50);


        builder.HasIndex(x => x.Id).IsUnique(true);
    }
}