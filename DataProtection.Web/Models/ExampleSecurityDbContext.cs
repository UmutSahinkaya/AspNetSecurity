using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataProtection.Web.Models;

public partial class ExampleSecurityDbContext : DbContext
{
    public ExampleSecurityDbContext()
    {
    }

    public ExampleSecurityDbContext(DbContextOptions<ExampleSecurityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
