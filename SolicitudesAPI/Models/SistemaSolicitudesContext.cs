using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SolicitudesAPI.Models;

public partial class SistemaSolicitudesContext : DbContext
{
    public SistemaSolicitudesContext()
    {
    }

    public SistemaSolicitudesContext(DbContextOptions<SistemaSolicitudesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendario> Calendario { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<DiaInhabilManual> DiaInhabilManual { get; set; }

    public virtual DbSet<Denuncia> Denuncias { get; set; }

    public virtual DbSet<AcuerdoSeguimiento> AcuerdosSeguimiento { get; set; }

    public virtual DbSet<ExpedienteDigital> ExpedientesDigitales { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.ToTable("Calendario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC27AA69A3A2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContenidoSolicitud)
                  .HasColumnType("nvarchar(max)"); // ahora soporta texto muy largo
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Folio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubsanaPrevencionReinicoTramite).HasColumnName("SubsanaPrevencion_ReinicoTramite");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27AA69A3A2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);

    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
