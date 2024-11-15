using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MilkTeaShopSaleSystem.DAL.Models;

public partial class MilkTeaShopSaleDbContext : DbContext
{
    public MilkTeaShopSaleDbContext()
    {
    }

    public MilkTeaShopSaleDbContext(DbContextOptions<MilkTeaShopSaleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database= MilkTeaShopSaleDB;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.DrinkId).HasName("PK__Drinks__C661FE9A46CB50E8");

            entity.HasIndex(e => e.DrinkName, "UQ__Drinks__26C95D039343F07F").IsUnique();

            entity.Property(e => e.DrinkId).HasColumnName("drink_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.DrinkName)
                .HasMaxLength(50)
                .HasColumnName("drink_name");
            entity.Property(e => e.DrinkStatus).HasColumnName("drink_status");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__46596229D4B270C4");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Orders__order_st__1A14E395");

            entity.HasMany(o => o.OrderDetails)
              .WithOne(od => od.Order)
              .HasForeignKey(od => od.OrderId)
              .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("Order_Detail"); // Explicitly set the table name

            entity.HasKey(e => new { e.OrderId, e.DrinkId, e.Size });

            entity.Property(e => e.DrinkId).HasColumnName("drink_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Size)
                  .HasMaxLength(20)
                  .HasColumnName("size");

            entity.HasOne(d => d.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(d => d.OrderId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Price)
                  .WithMany()
                  .HasForeignKey(d => new { d.DrinkId, d.Size })
                  .HasConstraintName("FK_OrderDetail_Price");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => new { e.DrinkId, e.Size }).HasName("PK__Prices__0499C974C3E4909F");

            entity.Property(e => e.DrinkId).HasColumnName("drink_id");
            entity.Property(e => e.Size)
                .HasMaxLength(20)
                .HasColumnName("size");
            entity.Property(e => e.Price1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceStatus).HasColumnName("price_status");

            entity.HasOne(d => d.Drink).WithMany(p => p.Prices)
                .HasForeignKey(d => d.DrinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__drink_id__173876EA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F7EE4B1BA");

            entity.HasIndex(e => e.UserName, "UQ__Users__7C9273C473ADFD88").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646DEF1D8E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .HasColumnName("user_role");
            entity.Property(e => e.UserStatus).HasColumnName("user_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
