using ECommerce.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base.BaseModel;

namespace ECommerce.Payment.Domain;

public class CreditAccount : BaseModel
{
    public int RetailerId { get; set; }
    public virtual Retailer Retailer { get; set; }
    public int AccountNo { get; set; }
    public string IBAN { get; set; }
    public double Balance { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? CloseDate { get; set; }

    public double ExpenseLimit { get; set; }
}

    public class CreditAccountConfiguration : IEntityTypeConfiguration<CreditAccount>
    {
        public void Configure(EntityTypeBuilder<CreditAccount> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.InsertDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.RetailerId).IsRequired(true);
            builder.Property(x => x.AccountNo).IsRequired(true);
            builder.Property(x => x.IBAN).IsRequired().HasMaxLength(34);
            builder.Property(x => x.Balance).IsRequired().HasPrecision(18, 2).HasDefaultValue(0);
            builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(3);
            builder.Property(x => x.OpenDate).IsRequired();
            builder.Property(x => x.CloseDate).IsRequired(false);

            builder.HasIndex(x => x.RetailerId);
            builder.HasIndex(x => x.AccountNo).IsUnique(true);


        }

    }


