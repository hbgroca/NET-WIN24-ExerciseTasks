using System;
using System.Collections.Generic;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<StatusType> StatusTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HBGROCA\\Desktop\\Github\\NET-WIN24-Uppgift-4\\Data\\Databases\\LocalDB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CompanyName).HasMaxLength(125);
            entity.Property(e => e.CompanyNr).HasMaxLength(125);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(125);
            entity.Property(e => e.LastName).HasMaxLength(125);
            entity.Property(e => e.PhoneNumber).HasMaxLength(25);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Projects_CustomerId");

            entity.HasIndex(e => e.EmployeeId, "IX_Projects_EmployeeId");

            entity.HasIndex(e => e.ServiceId, "IX_Projects_ServiceId");

            entity.HasIndex(e => e.StatusId, "IX_Projects_StatusId");

            entity.Property(e => e.ProjectName).HasMaxLength(125);
            entity.Property(e => e.ServiceCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Projects).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Employee).WithMany(p => p.Projects).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Service).WithMany(p => p.Projects).HasForeignKey(d => d.ServiceId);

            entity.HasOne(d => d.Status).WithMany(p => p.Projects).HasForeignKey(d => d.StatusId);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<StatusType>(entity =>
        {
            entity.ToTable("StatusType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
