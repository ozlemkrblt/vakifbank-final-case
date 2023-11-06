using ECommerce.Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("ReceiptInfo", Schema = "dbo")]
public class ReceiptInfo : BaseModel
{
    public string CompanyName { get; set; }
    public int? RetailerId { get; set; }
    public virtual Retailer Retailer { get; set; }

    public int? ReceiptId { get; set; }
    public virtual Receipt Receipt { get; set; }
    public int AddressId {  get; set; }
    public Address Address { get; set; }


    public int RetailerTaxNumber;
    public int MersisNo { get; set; }

    public override string ToString()
    {
        return $"RetailerId: {RetailerId}, RetailerUserName: {Retailer.UserName}, RetailerAddress: {Address?.ToString()}, RetailerTaxNumber: {RetailerTaxNumber}, MersisNo: {MersisNo}";
    }
}

public class ReceiptInfoConfiguration : IEntityTypeConfiguration<ReceiptInfo>
{
    public void Configure(EntityTypeBuilder<ReceiptInfo> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.RetailerId).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.AddressId).IsRequired(true);
        builder.Property(x => x.MersisNo).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.ReceiptId).HasDefaultValue(0).HasMaxLength(20);
        builder.Property(x => x.CompanyName).IsRequired(true).HasMaxLength(50);

    }
}