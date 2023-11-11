using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Payment.Domain;

namespace ECommerce.Data.Domain;

[Table("Retailer", Schema = "dbo")]
public class Retailer : User
{

    //retailer may have multiple receipt infos and choose between them in order process.
    public virtual List<ReceiptInfo> ReceiptInfos { get; set; } = new List<ReceiptInfo>();

    public virtual List<Order> Orders { get; set; } = new List<Order>();

    public virtual List<Card> Cards { get; set; } = new List<Card>();

    public int CheckAccountId { get; set; }
    public CheckAccount CheckAccount { get; set; }

    public int CreditAccountId { get; set; }
    public virtual CreditAccount CreditAccount {get; set;}

    public double ProfitMargin { get; set; } //ProfitMargin

}

public class RetailerConfiguration : IEntityTypeConfiguration<Retailer>
{
    public void Configure(EntityTypeBuilder<Retailer> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired();

        builder.HasMany(x => x.Orders)
       .WithOne(x => x.Retailer)
       .HasForeignKey(x => x.RetailerId)
       .IsRequired(true);


        builder.HasMany(x => x.ReceiptInfos)
            .WithOne(x => x.Retailer)
            .HasForeignKey(x => x.RetailerId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
       
        builder.HasMany(x => x.Cards)
        .WithOne(x => x.Retailer)
         .HasForeignKey(x => x.RetailerId)
        .IsRequired(true)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
