using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base;

namespace ECommerce.Data.Domain;

public class Receipt : BaseModel
{
    public int ReceiptInfoId { get; set; }
    public ReceiptInfo ReceiptInfo { get; set; }

    public int RetailerId {  get; set; }
    public Retailer Retailer { get; set; }



    //public Payment payment { get; set; }
    //public int PaymentId { get; set; }

}

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.ReceiptInfoId).IsRequired(true);
        builder.Property(x => x.RetailerId).IsRequired().HasMaxLength(10);


        builder.HasIndex(x => x.ReceiptInfoId).IsUnique(true);
        builder.HasIndex(x => x.RetailerId).IsUnique(true);

    }
}