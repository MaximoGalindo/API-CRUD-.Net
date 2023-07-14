using System;
using System.Collections.Generic;
using APICRUDDBfirst.Models;
using Microsoft.EntityFrameworkCore;

namespace APICRUDDBfirst.Data;

public partial class ContextDB : DbContext
{
    public ContextDB()
    {
    }

    public ContextDB(DbContextOptions<ContextDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Barco> Barcos { get; set; }

    public virtual DbSet<Socio> Socios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionDataBase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barco>(entity =>
        {
            entity.HasKey(e => e.IdBarco).HasName("Barco_pkey");

            entity.ToTable("Barco");

            entity.Property(e => e.IdBarco)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_barco");
            entity.Property(e => e.Cuota).HasColumnName("cuota");
            entity.Property(e => e.FechaLlegada).HasColumnName("fecha_llegada");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdSocio).HasColumnName("id_socio");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdSocioNavigation).WithMany(p => p.Barcos)
                .HasForeignKey(d => d.IdSocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_socio");
        });

        modelBuilder.Entity<Socio>(entity =>
        {
            entity.HasKey(e => e.IdSocio).HasName("Socio_pkey");

            entity.ToTable("Socio");

            entity.Property(e => e.IdSocio)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_socio");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
