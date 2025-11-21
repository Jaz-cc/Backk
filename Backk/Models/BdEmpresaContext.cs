using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backk.Models;

public partial class BdEmpresaContext : DbContext
{
    public BdEmpresaContext()
    {
    }

    public BdEmpresaContext(DbContextOptions<BdEmpresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }
    public virtual DbSet<Empresa> Empresas { get; set; }
    public virtual DbSet<Requisito> Requisitos { get; set; }
    public virtual DbSet<Vacante> Vacantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PRIMARY");

            entity.ToTable("contacto");

            entity.HasIndex(e => e.IdEmpresa, "id_empresa");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(100)
                .HasColumnName("nombre_contacto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contacto_ibfk_1");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PRIMARY");

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Sector)
                .HasMaxLength(100)
                .HasColumnName("sector");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(150)
                .HasColumnName("sitio_web");
        });

        modelBuilder.Entity<Requisito>(entity =>
        {
            entity.HasKey(e => e.IdRequisito).HasName("PRIMARY");

            entity.ToTable("requisitos");

            entity.HasIndex(e => e.IdVacante, "id_vacante");

            entity.Property(e => e.IdRequisito).HasColumnName("id_requisito");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdVacante).HasColumnName("id_vacante");

            entity.HasOne(d => d.IdVacanteNavigation).WithMany(p => p.Requisitos)
                .HasForeignKey(d => d.IdVacante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("requisitos_ibfk_1");
        });

        modelBuilder.Entity<Vacante>(entity =>
        {
            entity.HasKey(e => e.IdVacante).HasName("PRIMARY");

            entity.ToTable("vacantes");

            entity.HasIndex(e => e.IdEmpresa, "id_empresa");

            entity.Property(e => e.IdVacante).HasColumnName("id_vacante");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Salario)
                .HasPrecision(10, 2)
                .HasColumnName("salario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Vacantes)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vacantes_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
