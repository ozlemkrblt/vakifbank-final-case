using ECommerce.Base.BaseModel;
using ECommerce.Payment.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Domain;

namespace ECommerce.Payment.Domain;

public class OrderPayment :BaseModel
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentType PaymentType { get; set; } 
    public double PaymentAmount { get; set; }
    public DateTime PaymentDate{ get; set; }
    public virtual Card Card { get; set; }

    public virtual EFT EFT { get; set; }
    public virtual Transfer Transfer {  get; set; }
    public int CreditAccountId { get; set; }
    public virtual CreditAccount CreditAccount { get; set; }
}


public class PaymentConfiguration : IEntityTypeConfiguration<OrderPayment>
{
    public void Configure(EntityTypeBuilder<OrderPayment> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.OrderId).IsRequired(true);
        builder.Property(x => x.PaymentType).IsRequired(true);
        builder.Property(x => x.PaymentStatus).IsRequired().HasDefaultValue((PaymentStatus)1);
        builder.Property(x => x.PaymentAmount).IsRequired();

        builder.HasIndex(x => x.OrderId).IsUnique(true);
    }
}