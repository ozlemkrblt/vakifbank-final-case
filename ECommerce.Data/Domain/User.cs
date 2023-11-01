using ECommerce.Base;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;

public abstract class User : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    //public virtual List<Role> Roles { get; set; }

    public virtual List<Address> Addresses { get; set; }
    public abstract void Login();

}



public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    { }
}