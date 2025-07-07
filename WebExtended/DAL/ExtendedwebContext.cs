using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebExtended.DAL;

public partial class ExtendedwebContext : DbContext
{
    public ExtendedwebContext()
    {
    }

    public ExtendedwebContext(DbContextOptions<ExtendedwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<IncripcionEvento> IncripcionEventos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento);

            entity.Property(e => e.IdEvento)
                .ValueGeneratedNever()
                .HasColumnName("idEvento");
            entity.Property(e => e.Cupo).HasColumnName("cupo");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Fechaevento).HasColumnName("fechaevento");
            entity.Property(e => e.NombreEvento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreEvento");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<IncripcionEvento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IncripcionEvento");

            entity.Property(e => e.IdEvento).HasColumnName("idEvento");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d._evento).WithMany()
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK_IncripcionEvento_Eventos");

            entity.HasOne(d => d._usuario).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_IncripcionEvento_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
