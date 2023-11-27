using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoVar8wifArtem.Models
{
    public partial class Db8variantContext : DbContext
    {
        public Db8variantContext()
        {
        }
        public Db8variantContext(DbContextOptions<Db8variantContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<AgentType> AgentTypes { get; set; } = null!;
        public virtual DbSet<ProductSale> ProductSales { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Productss> Productsses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Db8variant;Trusted_Connection=True; TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.AgentName)
                    .HasMaxLength(50)
                    .HasColumnName("Agent_name");

                entity.Property(e => e.AgentTypeId).HasColumnName("Agent_type_id");

                entity.Property(e => e.DirectorName)
                    .HasMaxLength(50)
                    .HasColumnName("Director_name");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Inn)
                    .HasMaxLength(50)
                    .HasColumnName("INN");

                entity.Property(e => e.Kpp)
                    .HasMaxLength(50)
                    .HasColumnName("KPP");

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.AgentType)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AgentTypeId)
                    .HasConstraintName("FK_Agents_Agent_type");
            });

            modelBuilder.Entity<AgentType>(entity =>
            {
                entity.ToTable("Agent_type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.ToTable("Product_sale");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgentId).HasColumnName("Agent_id");

                entity.Property(e => e.CountOfProduct).HasColumnName("Count_of_product");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_Product_sale_Agents");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_sale_Productss");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Productss>(entity =>
            {
                entity.ToTable("Productss");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FactoryNumber).HasColumnName("Factory_number");

                entity.Property(e => e.MinAgentCost).HasColumnName("Min_agent_cost");

                entity.Property(e => e.PeopleForMade).HasColumnName("People_for_made");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("Product_name");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_type_id");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Productsses)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Productss_Product_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
