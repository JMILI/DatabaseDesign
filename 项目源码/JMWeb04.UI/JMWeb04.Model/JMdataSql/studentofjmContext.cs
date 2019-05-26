using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JMWeb04.Model.JMdataSql
{
    public partial class studentofjmContext : DbContext
    {
        public studentofjmContext()
        {
        }

        public studentofjmContext(DbContextOptions<studentofjmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;UserId=root;Password=admin;Database=studentofjm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClassCode).HasColumnType("varchar(100)");

                entity.Property(e => e.Name).HasColumnType("varchar(30)");

                entity.Property(e => e.Password).HasColumnType("varchar(100)");

                entity.Property(e => e.StudentId).HasColumnType("varchar(500)");
            });
        }
    }
}
