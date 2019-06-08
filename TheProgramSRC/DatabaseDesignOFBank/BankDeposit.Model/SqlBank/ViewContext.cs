﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankDeposit.Model.SqlBank
{
    public partial class ViewContext : bankContext
    {
        #region 含有储户名，储户账号，储户默认的银行卡号的视图
        /// <summary>
        /// 定义一个DbSet<DepositorAndCard>的集合属性DepositorAndCard，EF Core会自动为其赋值，然后可以利用ViewContextt.DepositorAndCard属性来读取数据库中DepositorAndCard视图的数据
        /// </summary>
        public virtual DbSet<DepositorAndCard> DepositorAndCard { get; set; }
        /// <summary>
        /// 在重写的OnModelCreating方法中，使用Fluent API来设置实体DepositorAndCard和数据库中DepositorAndCard视图的关系
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //先调用基类的OnModelCreating方法，设置数据库中其它表和实体的映射关系
            base.OnModelCreating(modelBuilder);

            //接着设置实体DepositorAndCard和数据库中DepositorAndCard视图的关系
            modelBuilder.Entity<DepositorAndCard>(entity =>
            {
                //告诉EF Core实体DepositorAndCard对应数据库中的DepositorAndCard视图，这里使用entity.ToTable方法后，上面的DbSet<DepositorAndCard> DepositorAndCard集合属性可以叫任何名字，比如我们可以将其定义为DbSet<DepositorAndCard> V_People也可以，如果不使用entity.ToTable方法，那么DbSet<DepositorAndCard> DepositorAndCard的属性名字必须和数据库视图DepositorAndCard的名字相同，否则EF Core会报错
                entity.ToTable("DepositorAndCard");

                //设置实体的唯一属性，因为我们知道数据库中DepositorAndCard视图的ID列值是唯一的，所以这里我们设置实体DepositorAndCard的Id属性为唯一属性
                entity.HasKey(e => e.Dcid);
                //利用Fluent API将实体DepositorAndCard的每一列映射到数据库视图的每一列
                entity.Property(e => e.Duid).HasColumnName("Duid");
                entity.Property(e => e.Dname).HasColumnName("Dname");
            });
        }
        #endregion

    }
}