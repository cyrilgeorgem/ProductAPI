using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Product.DAL.Entities
{
    public partial class AzureFDBContext : DbContext
    {
        public AzureFDBContext()
        {
        }

        public AzureFDBContext(DbContextOptions<AzureFDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBccategory> TblBccategories { get; set; } = null!;
        public virtual DbSet<TblBcitem> TblBcitems { get; set; } = null!;
        public virtual DbSet<TblDpcategory> TblDpcategories { get; set; } = null!;
        public virtual DbSet<TblDplogin> TblDplogins { get; set; } = null!;
        public virtual DbSet<TblDpproduct> TblDpproducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBccategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_BCCategories");

                entity.ToTable("tblBCCategories");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBcitem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_BCItems");

                entity.ToTable("tblBCItems");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfferPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblBcitems)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BCItems_BCCategories_CategoryId");
            });

            modelBuilder.Entity<TblDpcategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tblDPCat__19093A0B32291853");

                entity.ToTable("tblDPCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDplogin>(entity =>
            {
                entity.ToTable("tblDPLogin");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDpproduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblDPPro__B40CC6CD50B187D0");

                entity.ToTable("tblDPProduct");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblDpproducts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblDPProd__Categ__1AD3FDA4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
