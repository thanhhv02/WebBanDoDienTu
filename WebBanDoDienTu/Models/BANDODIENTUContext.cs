using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBanDoDienTu.Models
{
    public partial class BANDODIENTUContext : DbContext
    {
        public BANDODIENTUContext()
        {
        }

        public BANDODIENTUContext(DbContextOptions<BANDODIENTUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentTag> ContentTag { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3KE0OUQ\\T;Database=BANDODIENTU;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descriptions).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.MetaDescriptions)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.MetaTile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetalKeywords).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.MetaDescriptions)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.MetaTile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetalKeywords).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SeoTitle).HasMaxLength(250);

                entity.Property(e => e.ShowOnHome).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("ntext");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descriptions).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.MetaDescriptions)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.MetaTile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetalKeywords).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.TopHot).HasColumnType("datetime");
            });

            modelBuilder.Entity<ContentTag>(entity =>
            {
                entity.HasKey(e => new { e.ContentId, e.TagId });

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(32);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Content).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasColumnType("ntext");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.Target).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descriptions).HasMaxLength(500);

                entity.Property(e => e.Detail).HasColumnType("ntext");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.IncludedVat).HasColumnName("IncludedVAT");

                entity.Property(e => e.MetaDescriptions)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.MetaTile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetalKeywords).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.MoreImages).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.TopHot).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.MetaDescriptions)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.MetaTile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MetalKeywords).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SeoTitle).HasMaxLength(250);

                entity.Property(e => e.ShowOnHome).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
