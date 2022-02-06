using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable
namespace backend.Models
{
    public partial class bdfuncionarioContext : DbContext
    {
        public bdfuncionarioContext()
        {
        }

        public bdfuncionarioContext(DbContextOptions<bdfuncionarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCargo> TbCargos { get; set; }
        public virtual DbSet<TbEstado> TbEstados { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("host=localhost;user=root;password=12345;database=bdfuncionario", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<TbCargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cargo");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.DsCargo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ds_cargo");

                entity.Property(e => e.HrEntrada)
                    .HasColumnType("time")
                    .HasColumnName("hr_entrada");

                entity.Property(e => e.HrSaida)
                    .HasColumnType("time")
                    .HasColumnName("hr_saida");

                entity.Property(e => e.VlSalario)
                    .HasPrecision(15, 2)
                    .HasColumnName("vl_salario");
            });

            modelBuilder.Entity<TbEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("tb_estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.NmEstado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nm_estado");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_funcionario");

                entity.HasIndex(e => e.IdCargo, "id_cargo");

                entity.HasIndex(e => e.IdEstado, "id_estado");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.DsCelular)
                    .HasMaxLength(12)
                    .HasColumnName("ds_celular");

                entity.Property(e => e.DsCpf)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("ds_cpf");

                entity.Property(e => e.DsRg)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("ds_rg");

                entity.Property(e => e.DsTelefone)
                    .HasMaxLength(8)
                    .HasColumnName("ds_telefone");

                entity.Property(e => e.DtContratado)
                    .HasColumnType("date")
                    .HasColumnName("dt_contratado");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.NmFuncionario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nm_funcionario");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.TbFuncionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_funcionario_ibfk_1");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.TbFuncionarios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_funcionario_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
