using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base.BaseModel;

namespace ECommerce.Payment.Domain;
    public class EFT : BaseModel
    {
        public int SenderAccountId { get; set; }
        public virtual CheckAccount SenderAccount { get; set; }

        public string ReferenceNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverIBAN { get; set; }
         public double Amount { get; set; }
        public double ChargeAmount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Status { get; set; }
    }

public class EFTConfigruration : IEntityTypeConfiguration<EFT>
{
    public void Configure(EntityTypeBuilder<EFT> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.SenderAccountId).IsRequired(true);
        builder.Property(x => x.ReferenceNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TransactionDate).IsRequired();
        builder.Property(x => x.ReceiverIBAN).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ReceiverName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2).HasDefaultValue(0);
        builder.Property(x => x.ChargeAmount).IsRequired().HasPrecision(18, 2).HasDefaultValue(0);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(0);

        builder.HasIndex(x => x.SenderAccountId);

    }
}