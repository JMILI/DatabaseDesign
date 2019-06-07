using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBank.SqlBank
{
    class ViewContext:bankContext
    {
        /// <summary>
        /// 定义一个DbSet<Information>的集合属性Information，EF Core会自动为其赋值，然后可以利用ViewContextt.Information属性来读取数据库中Information视图的数据
        /// </summary>
        public virtual DbSet<Information> Information { get; set; }
        /// <summary>
        /// 在重写的OnModelCreating方法中，使用Fluent API来设置实体Information和数据库中Information视图的关系
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //先调用基类的OnModelCreating方法，设置数据库中其它表和实体的映射关系
            base.OnModelCreating(modelBuilder);

            //接着设置实体Information和数据库中Information视图的关系
            modelBuilder.Entity<Information>(entity =>
            {
                //告诉EF Core实体Information对应数据库中的Information视图，这里使用entity.ToTable方法后，上面的DbSet<Information> Information集合属性可以叫任何名字，比如我们可以将其定义为DbSet<Information> V_People也可以，如果不使用entity.ToTable方法，那么DbSet<Information> Information的属性名字必须和数据库视图Information的名字相同，否则EF Core会报错
                entity.ToTable("Information");

                //设置实体的唯一属性，因为我们知道数据库中Information视图的ID列值是唯一的，所以这里我们设置实体Information的Id属性为唯一属性
                entity.HasKey(e => e.Icid);
                //利用Fluent API将实体Information的每一列映射到数据库视图的每一列
                entity.Property(e => e.Iuid).HasColumnName("Iuid");
                entity.Property(e => e.Ioldtime).HasColumnName("Ioldtime");
                entity.Property(e => e.IflowBalance).HasColumnName("IflowBalance");
                entity.Property(e => e.IfixBalance).HasColumnName("IfixBalance");
                entity.Property(e => e.Iname).HasColumnName("Iname");
                entity.Property(e => e.Istatus).HasColumnName("Istatus");
            });
        }
    }
}
