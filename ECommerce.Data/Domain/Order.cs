using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Order", Schema = "dbo")]
public class Order : BaseModel
{

    public int OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public double PaymentStatus { get; set; }

    public int RetailerId { get; set; }  // one order can belong to one user
    public Retailer Retailer { get; set; }

    public int? ReceiptId { get; set; }
    public virtual Receipt Receipt { get; set; }
    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();  // one order can contain many orderitems
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.OrderNo).IsRequired(true);
        builder.Property(x => x.OrderDate).IsRequired(true);
        //builder.HasCheckConstraint("CK_OrderDate_NotInFuture", "OrderDate <= SYSDATETIME()");
        builder.Property(x => x.RetailerId).IsRequired().HasMaxLength(20);
        builder.Property(x => x.ReceiptId).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.Amount).IsRequired().HasPrecision(20,2);
        builder.Property(x => x.PaymentStatus).IsRequired().HasMaxLength(20);



        builder.HasIndex(x => x.ReceiptId).IsUnique(true);
        builder.HasIndex(x => x.RetailerId).IsUnique(true);
        builder.HasIndex(x => x.OrderNo).IsUnique(true);
        builder.HasIndex(x => x.Id).IsUnique(true);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .IsRequired(true);

        builder.HasOne(x => x.Receipt)
        .WithOne(x => x.Order)
        .HasForeignKey<Receipt>().IsRequired(true)   
        .IsRequired(true);
    }
}