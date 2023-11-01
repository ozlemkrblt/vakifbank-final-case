

using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;

    public class Message: BaseModel
    {

    //Sender (Admin / Retailer)
    //Receiver
    
    public string Text { get; set; }

    public DateTime SentTime { get; set; }

    }

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    { }
}