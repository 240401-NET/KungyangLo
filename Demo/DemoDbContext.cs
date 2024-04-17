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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:kungloprojects.database.windows.net,1433;Initial Catalog=demoDB;Persist Security Info=False;User ID=project-admin;Password=abc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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
