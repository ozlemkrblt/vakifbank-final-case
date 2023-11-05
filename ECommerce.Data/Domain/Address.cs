using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Base.BaseModel;

namespace ECommerce.Data.Domain;

[Table("Address", Schema = "dbo")]
public class Address : BaseModel
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.AddressLine1).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.AddressLine2).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.City).IsRequired().HasMaxLength(50);
        builder.Property(x => x.District).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);


    }
}