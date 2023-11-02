using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Domain;
    public class Retailer : User
    {

    //retailer may have multiple receipt infos and choose between them in order process.
    public virtual List<ReceiptInfo> ReceiptInfos { get; set; } = new List<ReceiptInfo>(); // one seller can order many times

    public virtual List<Order> Orders { get; set; } = new List<Order>(); // one seller can order many times

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

        builder.Property(x => x.Id).IsRequired(true);

        builder.HasMany(x => x.Orders)
       .WithOne(x => x.Retailer)
       .HasForeignKey(x => x.RetailerId)
       .IsRequired(true);


    }
}
