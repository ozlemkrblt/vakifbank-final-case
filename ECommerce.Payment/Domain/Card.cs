﻿using System.ComponentModel.DataAnnotations.Schema;

using ECommerce.Base.BaseModel;
using ECommerce.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Payment.Domain;

[Table("Card", Schema = "dbo")]
public class Card : BaseModel
{
    public string CardHolder { get; set; }
    public long CardNumber { get; set; }
    public string Cvv { get; set; } 
    public DateTime ExpiryDate { get; set; } // DDyy
    public int? ExpenseLimit { get; set; }
}




public class CardConfigruration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.CardHolder).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CardNumber).IsRequired();
        builder.Property(x => x.Cvv).IsRequired().HasMaxLength(3);
        builder.Property(x => x.ExpiryDate).IsRequired().HasMaxLength(4);
        builder.Property(x => x.ExpenseLimit).IsRequired(false);
    }
}