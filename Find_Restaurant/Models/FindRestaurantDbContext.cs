using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Find_Restaurant.Models;

public partial class FindRestaurantDbContext : DbContext
{
    public FindRestaurantDbContext()
    {
    }

    public FindRestaurantDbContext(DbContextOptions<FindRestaurantDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryDish> CategoryDishes { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=EMRAN-2023\\MSSQLSERVER2022;Database=Find-Restaurant-DB;Trusted_Connection=True;Trust Server Certificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryDish>(entity =>
        {
            entity.HasKey(e => e.DishTypeId);

            entity.ToTable("CategoryDish");

            entity.Property(e => e.DishName).HasMaxLength(50);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.ToTable("Restaurant");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactEmail).HasMaxLength(300);
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OpeningHours).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.DishType).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.DishTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_CategoryDish");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
