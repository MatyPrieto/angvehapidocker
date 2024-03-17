using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehiculosAngularConAPI.Models
{
    public partial class mantvehContext : DbContext
    {
        public mantvehContext()
        {
        }

        public mantvehContext(DbContextOptions<mantvehContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mantenimiento> Mantenimientos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Taller> Tallers { get; set; } = null!;
        public virtual DbSet<Trabajador> Trabajadors { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<VehiculoCarrocerium> VehiculoCarroceria { get; set; } = null!;
        public virtual DbSet<VehiculoCombustible> VehiculoCombustibles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=123456789;database=mantveh", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.IdMantenimiento)
                    .HasName("PRIMARY");

                entity.ToTable("mantenimiento");

                entity.HasIndex(e => e.IdTaller, "id_taller");

                entity.HasIndex(e => e.TrabajadorId, "trabajadorId");

                entity.Property(e => e.IdMantenimiento).HasColumnName("id_mantenimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.FechaTermino).HasColumnName("fecha_termino");

                entity.Property(e => e.IdTaller).HasColumnName("id_taller");

                entity.Property(e => e.PatenteForanea)
                    .HasMaxLength(8)
                    .HasColumnName("patente_foranea");

                entity.Property(e => e.TrabajadorId).HasColumnName("trabajadorId");

                entity.HasOne(d => d.IdTallerNavigation)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.IdTaller)
                    .HasConstraintName("mantenimiento_ibfk_1");

                entity.HasOne(d => d.Trabajador)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.TrabajadorId)
                    .HasConstraintName("mantenimiento_ibfk_2");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PRIMARY");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PRIMARY");

                entity.ToTable("modelo");

                entity.HasIndex(e => e.IdCarroceria, "id_carroceria");

                entity.HasIndex(e => e.IdCombustible, "id_combustible");

                entity.HasIndex(e => e.IdMarca, "id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdCarroceria).HasColumnName("id_carroceria");

                entity.Property(e => e.IdCombustible).HasColumnName("id_combustible");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.HasOne(d => d.IdCarroceriaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdCarroceria)
                    .HasConstraintName("modelo_ibfk_3");

                entity.HasOne(d => d.IdCombustibleNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdCombustible)
                    .HasConstraintName("modelo_ibfk_2");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("modelo_ibfk_1");
            });

            modelBuilder.Entity<Taller>(entity =>
            {
                entity.HasKey(e => e.IdTaller)
                    .HasName("PRIMARY");

                entity.ToTable("taller");

                entity.Property(e => e.IdTaller).HasColumnName("id_taller");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fono)
                    .HasMaxLength(15)
                    .HasColumnName("fono");

                entity.Property(e => e.NombreResponsable)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_responsable");

                entity.Property(e => e.NombreRz)
                    .HasMaxLength(255)
                    .HasColumnName("nombre_rz");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .HasColumnName("rut");
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.HasKey(e => e.IdTrabajador)
                    .HasName("PRIMARY");

                entity.ToTable("trabajador");

                entity.Property(e => e.IdTrabajador).HasColumnName("id_trabajador");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(255)
                    .HasColumnName("apellido_m");

                entity.Property(e => e.ApellidoP)
                    .HasMaxLength(255)
                    .HasColumnName("apellido_p");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .HasColumnName("rut");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fono)
                    .HasMaxLength(15)
                    .HasColumnName("fono");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .HasColumnName("rut");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Patente)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculo");

                entity.HasIndex(e => e.IdModelo, "id_modelo");

                entity.HasIndex(e => e.Patente, "patente")
                    .IsUnique();

                entity.Property(e => e.Patente)
                    .HasMaxLength(8)
                    .HasColumnName("patente");

                entity.Property(e => e.AceiteUtilizado)
                    .HasMaxLength(255)
                    .HasColumnName("aceite_utilizado");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Aro).HasColumnName("aro");

                entity.Property(e => e.Bujia)
                    .HasMaxLength(255)
                    .HasColumnName("bujia");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.DescripcionVehiculo)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion_vehiculo");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.NumeroChasis)
                    .HasMaxLength(17)
                    .HasColumnName("numero_chasis");

                entity.Property(e => e.PresionNeumatico)
                    .HasMaxLength(255)
                    .HasColumnName("presion_neumatico");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("vehiculo_ibfk_1");
            });

            modelBuilder.Entity<VehiculoCarrocerium>(entity =>
            {
                entity.HasKey(e => e.IdCarroceria)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculo_carroceria");

                entity.Property(e => e.IdCarroceria).HasColumnName("id_carroceria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<VehiculoCombustible>(entity =>
            {
                entity.HasKey(e => e.IdCombustible)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculo_combustible");

                entity.Property(e => e.IdCombustible).HasColumnName("id_combustible");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
