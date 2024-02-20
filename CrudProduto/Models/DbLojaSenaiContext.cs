using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudProduto.Models
{
    public partial class DbLojaSenaiContext : DbContext
    {
        public DbLojaSenaiContext()
        {
        }

        public DbLojaSenaiContext(DbContextOptions<DbLojaSenaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Fornecedor> Fornecedors { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10BC8A9FC5");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__Forneced__22E24EC633D4548C");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__produto__IdCateg__286302EC");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__produto__IdForne__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
