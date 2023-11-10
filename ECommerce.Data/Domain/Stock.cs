using ECommerce.Base.BaseModel;
using ECommerce.Base.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain;
public class Stock : BaseModel
{
    public int MaxStock { get; set; }
    public int StockValue { get; set; }

    public virtual StockStatus StockStatus {get ; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

}

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.MaxStock).HasDefaultValue(1000);
        builder.Property(x => x.StockValue).IsRequired(true);
        builder.Property(x => x.StockStatus).HasDefaultValue(StockStatus.InStock);  
        builder.HasIndex(x => x.ProductId).IsUnique(true);


    }
}