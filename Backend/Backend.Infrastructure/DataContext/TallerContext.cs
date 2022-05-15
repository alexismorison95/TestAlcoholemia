using System;
using System.Collections.Generic;
using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Infrastructure.DataContext
{
    public partial class TallerContext : DbContext
    {
        public TallerContext()
        {
        }

        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Dominio> Dominios { get; set; } = null!;
        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<Examinador> Examinadors { get; set; } = null!;
        public virtual DbSet<Periodoutilizable> Periodoutilizables { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Prueba> Pruebas { get; set; } = null!;
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Taller;Username=postgres;Password=alexis");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("conductor_pkey");

                entity.ToTable("conductor");

                entity.Property(e => e.Dni)
                    .HasColumnType("character varying")
                    .HasColumnName("dni");

                entity.Property(e => e.Apellido)
                    .HasColumnType("character varying")
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Dominio>(entity =>
            {
                entity.HasKey(e => e.Patente)
                    .HasName("dominio_pkey");

                entity.ToTable("dominio");

                entity.Property(e => e.Patente)
                    .HasColumnType("character varying")
                    .HasColumnName("patente");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("character varying")
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("equipo");

                entity.HasIndex(e => e.Nombre, "equipo_nombre_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");

                entity.Property(e => e.Nroactual).HasColumnName("nroactual");
            });

            modelBuilder.Entity<Examinador>(entity =>
            {
                entity.ToTable("examinador");

                entity.HasIndex(e => e.Usuarionombre, "examinador_usuarionombre_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Usuarionombre)
                    .HasColumnType("character varying")
                    .HasColumnName("usuarionombre");

                entity.HasOne(d => d.UsuarionombreNavigation)
                    .WithOne(p => p.Examinador)
                    .HasForeignKey<Examinador>(d => d.Usuarionombre)
                    .HasConstraintName("examinador_usuarionombre_fkey");
            });

            modelBuilder.Entity<Periodoutilizable>(entity =>
            {
                entity.ToTable("periodoutilizable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Equipoid).HasColumnName("equipoid");

                entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");

                entity.Property(e => e.Fechavencimiento).HasColumnName("fechavencimiento");

                entity.Property(e => e.Nroingreso).HasColumnName("nroingreso");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Periodoutilizables)
                    .HasForeignKey(d => d.Equipoid)
                    .HasConstraintName("periodoutilizable_equipoid_fkey");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("prestamo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Equipoid).HasColumnName("equipoid");

                entity.Property(e => e.Examinadorid).HasColumnName("examinadorid");

                entity.Property(e => e.Fechadevolucion).HasColumnName("fechadevolucion");

                entity.Property(e => e.Fechaprestamo).HasColumnName("fechaprestamo");

                entity.Property(e => e.Horadevolucion).HasColumnName("horadevolucion");

                entity.Property(e => e.Horaprestamo).HasColumnName("horaprestamo");

                entity.Property(e => e.Nrodevolucion).HasColumnName("nrodevolucion");

                entity.Property(e => e.Nroinicial).HasColumnName("nroinicial");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Equipoid)
                    .HasConstraintName("prestamo_equipoid_fkey");

                entity.HasOne(d => d.Examinador)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Examinadorid)
                    .HasConstraintName("prestamo_examinadorid_fkey");
            });

            modelBuilder.Entity<Prueba>(entity =>
            {
                entity.ToTable("prueba");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Conductordni)
                    .HasColumnType("character varying")
                    .HasColumnName("conductordni");

                entity.Property(e => e.Descripcionrechazo)
                    .HasColumnType("character varying")
                    .HasColumnName("descripcionrechazo");

                entity.Property(e => e.Dominioid)
                    .HasColumnType("character varying")
                    .HasColumnName("dominioid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.Nroacta).HasColumnName("nroacta");

                entity.Property(e => e.Nromuestra).HasColumnName("nromuestra");

                entity.Property(e => e.Nroretencion).HasColumnName("nroretencion");

                entity.Property(e => e.Prestamoid).HasColumnName("prestamoid");

                entity.Property(e => e.Rechazado).HasColumnName("rechazado");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.Verificado).HasColumnName("verificado");

                entity.Property(e => e.Verificadornombre)
                    .HasColumnType("character varying")
                    .HasColumnName("verificadornombre");

                entity.HasOne(d => d.ConductordniNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Conductordni)
                    .HasConstraintName("prueba_conductordni_fkey");

                entity.HasOne(d => d.Dominio)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Dominioid)
                    .HasConstraintName("prueba_dominioid_fkey");

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Prestamoid)
                    .HasConstraintName("prueba_prestamoid_fkey");

                entity.HasOne(d => d.VerificadornombreNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.Verificadornombre)
                    .HasConstraintName("prueba_verificadornombre_fkey");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.ToTable("tipousuario");

                entity.HasIndex(e => e.Tipo, "tipousuario_tipo_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasColumnType("character varying")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Nombreusuario)
                    .HasName("usuario_pkey");

                entity.ToTable("usuario");

                entity.Property(e => e.Nombreusuario)
                    .HasColumnType("character varying")
                    .HasColumnName("nombreusuario");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Contrasenia)
                    .HasColumnType("character varying")
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Nombrereal)
                    .HasColumnType("character varying")
                    .HasColumnName("nombrereal");

                entity.Property(e => e.Tipousuarioid).HasColumnName("tipousuarioid");

                entity.HasOne(d => d.Tipousuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Tipousuarioid)
                    .HasConstraintName("usuario_tipousuarioid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
