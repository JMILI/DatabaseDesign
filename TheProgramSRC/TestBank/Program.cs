using System;
using System.Linq;
using TestBank.SqlBank;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace TestBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Users user = new Users();
            Information infomation = new Information();
            #region 操作数据库中的视图
            using (ViewContext dbContext = new ViewContext())
            {
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
                var vPersons = dbContext.Information.AsNoTracking().ToList();
                infomation = dbContext.Information.FirstOrDefault(a => a.Icid == 20001);
                Console.WriteLine(infomation.Icid);
                Console.WriteLine(infomation.Ioldtime);
                foreach (var vPerson in vPersons)
                {
                    Console.Write(infomation.Icid + " ");
                    Console.Write(infomation.Iuid + " ");
                    Console.Write(infomation.Ioldtime + " ");
                    Console.Write(infomation.IflowBalance + " ");
                    Console.Write(infomation.IfixBalance + " ");
                    Console.Write(infomation.Iname + " ");
                    Console.WriteLine(infomation.Istatus + " ");
                }
                Console.WriteLine($"Information视图有{vPersons.Count.ToString()}行数据");
                Console.WriteLine(vPersons[0].Icid.ToString());

                #region 计算利息原理
                //时间差值计算利息
                //1. C# DateTime转成MySQL DateTime的字符串：
                //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //2. MySQL 读出的DateTime转换成C#的DateTime
                DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(infomation.Ioldtime).ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine(infomation.Ioldtime);//查看数据库视图中的旧时间字段
                DateTime dt2 = System.DateTime.Now;//生成新的系统时间
                Console.WriteLine(DateTime.Now);//打印现在时间
                Double Day = dt2.Day - dt1.Day;//天数差值
                Console.WriteLine(Day);
                Double Month = (dt2.Year - dt1.Year) * 12 + (dt2.Month - dt1.Month);//月数差值
                Day = Day * 0.2;
                Console.WriteLine(Day);
                #endregion
            }
            #endregion
            #region 事务操作
            using (var dbContext = new bankContext())
            {
                //事务操作
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //事务适合同时利用sql语句修改多个数据库表中的字段时，每条都要执行dbContext.SaveChanges()，而多条修改就需要事务提交。否则出错。
                        //第一个更改数据库操作
                        user = dbContext.Users.FirstOrDefault(a => a.Uid == 10001);
                        user.Uname = "newName" + (new Random().Next(1, 100));
                        dbContext.SaveChanges();
                        //第二个更改数据库操作
                        var id = 10001;
                        var uname = "王二麻子";
                        var sql = @"Update Users SET Uname =  {0} WHERE Uid =  {1}";
                        dbContext.Database.ExecuteSqlCommand(sql, uname, id);
                        //保存数据
                        dbContext.SaveChanges();
                        //提交，如果不写并不会报错，但是数据库不会更新
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
            }
            #endregion
        }
    }
}
