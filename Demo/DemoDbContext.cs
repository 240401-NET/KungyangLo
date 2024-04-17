using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo;

public partial class DemoDbContext : DbContext
{
    public DemoDbContext()
    {
    }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tool> Tools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tool>(entity =>
        {
            entity.HasKey(e => e.ToolId).HasName("PK_TransactionHistoryArchive1_TransactionID");

            entity.Property(e => e.ToolId).HasColumnName("tool_id");
            entity.Property(e => e.BattV).HasColumnName("battV");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ToolType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tool_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
