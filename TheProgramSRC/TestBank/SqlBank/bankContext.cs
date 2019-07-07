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
        public virtual DbSet<Depositors> Depositors { get; set; }
        public virtual DbSet<Fixbalances> Fixbalances { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Records> Records { get; set; }

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
                    .HasName("FK_Reference_1");

                entity.Property(e => e.Cid).HasColumnType("int(100)");

                entity.Property(e => e.CflowBalance)
                    .HasColumnType("double(200,5)")
                    .HasDefaultValueSql("'0.00000'");

                entity.Property(e => e.CflowBalanceRate).HasColumnType("double(200,5)");

                entity.Property(e => e.Cpassword)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Cuid).HasColumnType("int(100)");

                entity.HasOne(d => d.Cu)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.Cuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reference_1");
            });

            modelBuilder.Entity<Depositors>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("depositors");

                entity.Property(e => e.Uid).HasColumnType("int(100)");

                entity.Property(e => e.Ucid).HasColumnType("int(100)");

                entity.Property(e => e.Uidentify)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasDefaultValueSql("'储户'");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Upassword)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Ustatus)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasDefaultValueSql("'正常'");
            });

            modelBuilder.Entity<Fixbalances>(entity =>
            {
                entity.HasKey(e => e.Fid);

                entity.ToTable("fixbalances");

                entity.Property(e => e.Fid).HasColumnType("int(100)");

                entity.Property(e => e.FbusinessTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Fcid).HasColumnType("int(100)");

                entity.Property(e => e.FfixBalance)
                    .HasColumnType("double(200,3)")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.FfixBalanceRate)
                    .HasColumnType("double(200,5)")
                    .HasDefaultValueSql("'0.00000'");

                entity.Property(e => e.Fmid).HasColumnType("int(100)");

                entity.Property(e => e.Fyear)
                    .HasColumnType("int(50)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.Mid);

                entity.ToTable("managers");

                entity.Property(e => e.Mid).HasColumnType("int(100)");

                entity.Property(e => e.Midentify)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasDefaultValueSql("'管理员'");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Mpassword)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Records>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("records");

                entity.Property(e => e.Rid).HasColumnType("int(100)");

                entity.Property(e => e.Rcid).HasColumnType("int(100)");

                entity.Property(e => e.RfixDepostit)
                    .HasColumnType("double(200,3)")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.RflowDeposit)
                    .HasColumnType("double(200,3)")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.Rmid).HasColumnType("int(100)");

                entity.Property(e => e.RnowDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Ruid).HasColumnType("int(100)");

                entity.Property(e => e.Rwithdrawals)
                    .HasColumnType("double(200,3)")
                    .HasDefaultValueSql("'0.000'");
            });
        }
    }
}
