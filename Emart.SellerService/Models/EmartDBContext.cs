using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Emart.SellerService.Models
{
    public partial class EmartDBContext : DbContext
    {
        public EmartDBContext()
        {
        }

        public EmartDBContext(DbContextOptions<EmartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GSELM9H\\SQLEXPRESS;Initial Catalog=EmartDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Buyer__DE90ADE7C77C3109");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bdate)
                    .HasColumnName("bdate")
                    .HasColumnType("date");

                entity.Property(e => e.Bemail)
                    .HasColumnName("bemail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bname)
                    .HasColumnName("bname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bno)
                    .HasColumnName("bno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bpwd)
                    .HasColumnName("bpwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Cartid)
                    .HasColumnName("cartid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Iid).HasColumnName("iid");

                entity.Property(e => e.Imagepath)
                    .HasColumnName("imagepath")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasColumnName("itemName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Scid).HasColumnName("scid");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.StockNo).HasColumnName("stockNo");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__category__D837D05F68778BCA");

                entity.ToTable("category");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdetails)
                    .HasColumnName("cdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Iid)
                    .HasName("PK__Items__C4962F8467EADE9A");

                entity.Property(e => e.Iid).ValueGeneratedNever();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Imagepath)
                    .HasColumnName("imagepath")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Scid).HasColumnName("scid");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.StockNo).HasColumnName("stock_no");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Items__cid__1B0907CE");

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Scid)
                    .HasConstraintName("FK__Items__scid__1BFD2C07");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK__Items__sid__21B6055D");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK__Purchase__C451DB31638CB8D9");

                entity.ToTable("Purchase_History");

                entity.Property(e => e.Tid).ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoOfItems).HasColumnName("No_of_Items");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transaction_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.PurchaseHistory)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK__Purchase_Hi__bid__1ED998B2");

                entity.HasOne(d => d.I)
                    .WithMany(p => p.PurchaseHistory)
                    .HasForeignKey(d => d.Iid)
                    .HasConstraintName("FK__Purchase_Hi__Iid__20C1E124");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.PurchaseHistory)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK__Purchase_Hi__sid__1FCDBCEB");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Seller__DDDFDD36B2A90194");

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BreifAboutCompany)
                    .HasColumnName("breif_about_company")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gstin)
                    .HasColumnName("gstin")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasColumnName("postal_address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Scompany)
                    .HasColumnName("scompany")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Semail)
                    .HasColumnName("semail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Spwd)
                    .HasColumnName("spwd")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.Scid)
                    .HasName("PK__subcateg__320EA6B5AB7C6514");

                entity.ToTable("subcategory");

                entity.Property(e => e.Scid)
                    .HasColumnName("scid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Gst)
                    .HasColumnName("gst")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Scdetails)
                    .HasColumnName("scdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__subcategory__cid__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
