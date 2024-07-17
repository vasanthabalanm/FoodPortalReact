using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelManageDL.Models;

public partial class HotelManagingApplicationContext : DbContext
{
    public HotelManagingApplicationContext()
    {
    }

    public HotelManagingApplicationContext(DbContextOptions<HotelManagingApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelBranch> HotelBranches { get; set; }

    public virtual DbSet<MenuDetail> MenuDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<UserViewMenuEntity> UserViewMenuEntities { get; set; }
    public virtual DbSet<PendingOrderEntity> PendingOrderEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KANINI-LTP-511;Database=FoodHotelManager;User Id=sa;Password=Balan@kanini14;Encrypt=False;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotel__3214EC075F79FFDA");

            entity.ToTable("Hotel");
        });

        modelBuilder.Entity<HotelBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HotelBra__3214EC07CCF7AA69");

            entity.ToTable("HotelBranch");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelBranches)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__HotelBran__Hotel__398D8EEE");
        });

        modelBuilder.Entity<MenuDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuDeta__3214EC07EA4AAB1F");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.HotelBranch).WithMany(p => p.MenuDetails)
                .HasForeignKey(d => d.HotelBranchId)
                .HasConstraintName("FK__MenuDetai__Hotel__3C69FB99");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07EF888EEB");

            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.HotelBranch).WithMany(p => p.Orders)
                .HasForeignKey(d => d.HotelBranchId)
                .HasConstraintName("FK__Orders__HotelBra__3F466844");

            entity.HasOne(d => d.MenuDetails).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MenuDetailsId)
                .HasConstraintName("FK__Orders__MenuDeta__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
