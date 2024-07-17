using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderDL.Models;

public partial class FoodOrderOwnerApplicationContext : DbContext
{
    public FoodOrderOwnerApplicationContext()
    {
    }

    public FoodOrderOwnerApplicationContext(DbContextOptions<FoodOrderOwnerApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApprovedUser> ApprovedUsers { get; set; }

    public virtual DbSet<PendingUser> PendingUsers { get; set; }
    public virtual DbSet<ApprovedUserEntity> ApprovedUserEntitys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KANINI-LTP-511;Database=FoodOwner;User Id=sa;Password=Balan@kanini14;Encrypt=False;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApprovedUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approved__3214EC0786D06BFD");
        });

        modelBuilder.Entity<PendingUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PendingU__3214EC0740764EE9");

            entity.ToTable("PendingUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
