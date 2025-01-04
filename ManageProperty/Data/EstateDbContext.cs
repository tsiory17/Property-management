﻿using System;
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



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SAIUMEB;Initial Catalog=EstateDb;User=sa;Password=lasalle;Integrated Security=True;TrustServerCertificate=True;");

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

    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Event> Events { get; set; } = default!;
}
