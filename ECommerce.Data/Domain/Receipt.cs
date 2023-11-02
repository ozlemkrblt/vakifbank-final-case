﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerce.Base;

namespace ECommerce.Data.Domain;

public class Receipt : BaseModel
{
    public int ReceiptInfoId { get; set; }
    public ReceiptInfo ReceiptInfo { get; set; }

    public int RetailerId {  get; set; }
    public Retailer Retailer { get; set; }



    //public Payment payment { get; set; }
    public int PaymentId { get; set; }

}

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    { }
}