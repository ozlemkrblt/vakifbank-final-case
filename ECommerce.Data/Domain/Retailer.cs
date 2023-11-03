using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Retailer", Schema = "dbo")]
public class Retailer : User
    {

    //retailer may have multiple receipt infos and choose between them in order process.
    public virtual List<ReceiptInfo> ReceiptInfos { get; set; } = new List<ReceiptInfo>(); 

    public virtual List<Order> Orders { get; set; } = new List<Order>(); 

       // Özel Fiyatlandırma(Kar marjı, anlaşmalı fiyatlar vb.)
//Açık Hesap Limiti

        public override void Login()
        {
            throw new NotImplementedException();
        }
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

    }
}
