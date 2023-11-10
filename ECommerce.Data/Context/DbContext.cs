﻿using Microsoft.EntityFrameworkCore;
using ECommerce.Data.Domain;

namespace ECommerce.Data.Context;
public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("AdminIdSequence", schema: "dbo")
        .StartsAt(10000000) 
        .IncrementsBy(1);

        modelBuilder.HasSequence<int>("UserIdSequence", schema: "dbo")
    .StartsAt(20000000)
    .IncrementsBy(1);

        modelBuilder.Entity<User>().UseTptMappingStrategy();
        modelBuilder.ApplyConfiguration(new AddressConfiguration ());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        modelBuilder.ApplyConfiguration(new ReceiptInfoConfiguration());
        modelBuilder.ApplyConfiguration(new RetailerConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}


