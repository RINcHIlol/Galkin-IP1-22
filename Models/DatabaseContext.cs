using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru;Database=db504;Username=user504;Password=87321");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Buyer).HasColumnName("buyer");
            entity.Property(e => e.Inn)
                .HasMaxLength(255)
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Salesman).HasColumnName("salesman");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Manufacturer_pkey");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Orders_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Orders_customer_id_fkey");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("Orders_manufacturer_id_fkey");
        });

        modelBuilder.Entity<OrdersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Orders_Products_pkey");

            entity.ToTable("Orders_Products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("Orders_Products_order_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("Orders_Products_product_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count)
                .HasPrecision(10, 2)
                .HasColumnName("count");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Name)
                .HasMaxLength(155)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("Products_manufacturer_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roles_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("Users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
