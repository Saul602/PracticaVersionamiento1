using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaVersionamiento1.Models;

public partial class TallerAutomotrizContext : DbContext
{
    public TallerAutomotrizContext()
    {
    }

    public TallerAutomotrizContext(DbContextOptions<TallerAutomotrizContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Automovil> Automovils { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Entregan> Entregans { get; set; }

    public virtual DbSet<Registra> Registras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=TallerAutomotriz;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automovil>(entity =>
        {
            entity.HasKey(e => e.IdAutomovil).HasName("PK__Automovi__3D90B2E38ED367A1");

            entity.ToTable("Automovil");

            entity.Property(e => e.IdAutomovil).ValueGeneratedNever();
            entity.Property(e => e.Defecto).HasMaxLength(255);
            entity.Property(e => e.Modelo).HasMaxLength(100);
            entity.Property(e => e.Placas).HasMaxLength(20);

            entity.HasOne(d => d.IdEntreganNavigation).WithMany(p => p.Automovils)
                .HasForeignKey(d => d.IdEntregan)
                .HasConstraintName("FK__Automovil__IdEnt__2F10007B");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642D333F9D3");

            entity.Property(e => e.IdCliente).ValueGeneratedNever();
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(100);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdRegistroNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdRegistro)
                .HasConstraintName("FK_Clientes_Registra");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9EB7BAB90F");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).ValueGeneratedNever();
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(100);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Entregan>(entity =>
        {
            entity.HasKey(e => e.IdEntregan).HasName("PK__Entregan__1C4F0D51D7AE3F67");

            entity.ToTable("Entregan");

            entity.Property(e => e.IdEntregan).ValueGeneratedNever();

            entity.HasOne(d => d.IdAutomovilNavigation).WithMany(p => p.Entregans)
                .HasForeignKey(d => d.IdAutomovil)
                .HasConstraintName("FK_Entregan_Automovil");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Entregans)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Entregan_Cliente");
        });

        modelBuilder.Entity<Registra>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registra__FFA45A99B54B2A92");

            entity.ToTable("Registra");

            entity.Property(e => e.IdRegistro).ValueGeneratedNever();
            entity.Property(e => e.FechaHoraRegistro).HasColumnType("datetime");
            entity.Property(e => e.Lugar).HasMaxLength(100);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Registras)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Registra__IdClie__29572725");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Registras)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Registra__IdEmpl__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
