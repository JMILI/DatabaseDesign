using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestBank.SqlBank
{
    public partial class bankContext : DbContext
    {
        public bankContext()
        {
        }

        public bankContext(DbContextOptions<bankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cards> Cards { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<Users> Users { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;UserId=root;Password=admin;Database=bank");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cards>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("cards");

                entity.HasIndex(e => e.Cuid)
                    .HasName("FK_Reference_2");

                entity.Property(e => e.Cid).HasColumnType("int(100)");

                entity.Property(e => e.Cpassword).HasColumnType("varchar(200)");

                entity.Property(e => e.Cuid).HasColumnType("int(100)");

                entity.HasOne(d => d.Cu)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.Cuid)
                    .HasConstraintName("FK_Reference_2");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.ToTable("managers");

                entity.Property(e => e.Mid).HasColumnType("int(100)");

                entity.Property(e => e.Midentify).HasColumnType("varchar(200)");

                entity.Property(e => e.Mname).HasColumnType("varchar(200)");

                entity.Property(e => e.Mpassword).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Records>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("records");

                entity.HasIndex(e => e.Rcid)
                    .HasName("FK_Reference_4");

                entity.Property(e => e.Rid).HasColumnType("int(100)");

                entity.Property(e => e.Rcid).HasColumnType("int(100)");

                entity.Property(e => e.RnowDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Ruid).HasColumnType("int(100)");

                entity.HasOne(d => d.Rc)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Rcid)
                    .HasConstraintName("FK_Reference_4");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("users");

                entity.Property(e => e.Uid).HasColumnType("int(100)");

                entity.Property(e => e.Ucid).HasColumnType("int(100)");

                entity.Property(e => e.Uname).HasColumnType("varchar(200)");

                entity.Property(e => e.Upassword).HasColumnType("varchar(200)");

                entity.Property(e => e.Ustatus).HasColumnType("varchar(200)");
            });
        }
    }
}
