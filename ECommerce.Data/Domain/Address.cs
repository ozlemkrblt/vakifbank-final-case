
using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;

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
    { }
}