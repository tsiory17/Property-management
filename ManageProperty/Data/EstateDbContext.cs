using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ManageProperty.Models;

namespace ManageProperty.Data;

public partial class EstateDbContext : DbContext
{
    public EstateDbContext()
    {
    }

    public EstateDbContext(DbContextOptions<EstateDbContext> options)
        : base(options)
    {
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.SentAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Owner> Owners { get; set; } = default!;

    public DbSet<Manager> Managers { get; set; } = default!;

    public DbSet<Tenant> Tenants { get; set; } = default!;

    public DbSet<Building> Buildings { get; set; } = default!;

    public DbSet<Apartment> Apartments { get; set; } = default!;

    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<ApartmentImage> ApartmentImages { get; set; } = default!;

    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Event> Events { get; set; } = default!;
}
