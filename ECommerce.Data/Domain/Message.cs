using ECommerce.Base.BaseModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Message", Schema = "dbo")]
public class Message : BaseModel
{
    public int SenderId  { get; set; }
    public Retailer Sender { get; set; }

    public int ReceiverId { get; set; }
    public Admin Receiver { get; set; }


    public string Text { get; set; }

    public DateTime SentTime { get; set; }

}

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.ReceiverId).IsRequired(true);
        builder.Property(x => x.SenderId).IsRequired(true);

        builder.HasIndex(x =>  x.SenderId).IsUnique();
        builder.HasIndex(x => x.ReceiverId).IsUnique();

        builder.HasOne(x => x.Sender)
               .WithMany()
               .HasForeignKey(x => x.SenderId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(x => x.Receiver)
               .WithMany()
               .HasForeignKey(x => x.ReceiverId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict); 

    }
}