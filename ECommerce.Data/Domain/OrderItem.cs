using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Base.BaseModel;

namespace ECommerce.Data.Domain;

[Table("OrderItem", Schema = "dbo")]
public class OrderItem : BaseModel
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ProductQuantity{ get; set; } // how many products 

}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.OrderId).IsRequired(true);
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.ProductQuantity).IsRequired(true).HasDefaultValue(0);


        builder.HasIndex(x => x.OrderId).IsUnique(true);
        builder.HasIndex(x => x.ProductId).IsUnique(true);
    }
}