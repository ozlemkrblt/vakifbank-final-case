using ECommerce.Base.BaseModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("User", Schema = "dbo")]
public abstract class User : BaseModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    
    public int RoleId { get; set; }
    public  Role Role { get; set; }

    public virtual List<Address> Addresses { get; set; }
    public abstract void Login();

}



public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.RoleId).IsRequired(true);
        // builder.Property(x => x.LastActivityDate).IsRequired();
        //builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.HasIndex(x => x.Email).IsUnique(true);
        builder.HasIndex(x => x.UserName).IsUnique(true);


        builder.HasMany(x => x.Addresses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);


    }
}