using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Receipt", Schema = "dbo")]
public class Receipt : BaseModel
{
    public int ReceiptInfoId { get; set; }
    public ReceiptInfo ReceiptInfo { get; set; }

    public int OrderId {  get; set; }
    public virtual Order Order { get; set; }



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
        builder.Property(x => x.OrderId).IsRequired().HasMaxLength(10);


        builder.HasIndex(x => x.ReceiptInfoId).IsUnique(true);
        builder.HasIndex(x => x.OrderId).IsUnique(true);

        builder.HasOne(x => x.ReceiptInfo)
        .WithOne(x => x.Receipt)
        .HasForeignKey<ReceiptInfo>(x=> x.ReceiptId).IsRequired(true)
        .IsRequired(true).OnDelete(DeleteBehavior.NoAction); ;
    }
}