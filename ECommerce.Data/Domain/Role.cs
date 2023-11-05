using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Role", Schema = "dbo")]
public class Role : BaseModel
{
    public string Name { get; set; }    
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
    }
}