using System;
using System.Linq;
using TestBank.SqlBank;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TestBank
{
    class Program
    {
        public static string MD5Encrypt64(string password)
        { 
            string cl = password;
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        static void Main(string[] args)
        {
            Depositors depositors = new Depositors();
            Information infomation = new Information();
            #region 操作数据库中的视图

            string s = "30005";
            //MD5Encrypt64(MD5Encrypt64(s));
            Console.WriteLine(MD5Encrypt64(s));
            //Console.WriteLine(MD5Encrypt64(MD5Encrypt64(s)));
            using (ViewContext dbContext = new ViewContext())
            {


                //SELECT* FROM 表名 WHERE TO_DAYS(NOW()) - TO_DAYS(Ioldtime) <= 1
                //var mid = 30001;
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
                //var vPersons = dbContext.Information.FromSql("select * from Information where Imid={0} and DateDiff(dd, Ioldtime, getdate()-1) = 0", mid).AsNoTracking().ToList();
                //select* from 数据表 where  DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= 你要判断的时间字段名
                //select* from Information where  DATE_SUB(CURDATE(), INTERVAL 7 DAY) <= Ioldtime
                //var vPersons = dbContext.Information.FromSql(
                //    "SELECT* FROM  Information WHERE YEARWEEK(date_format(Ioldtime, '%Y-%m-%d')) = YEARWEEK(now()) and Imid={0}",mid).AsNoTracking().ToList();
                //       var vPersons =  dbContext.Information.FromSql(
                //" SELECT* FROM  Information WHERE DATE_FORMAT(Ioldtime, '%Y%m') = DATE_FORMAT(CURDATE(), '%Y%m') and Imid={0}", mid)
                //.AsNoTracking().ToList();
                //var vPersons = dbContext.Information.
                //select* from Information where to_days(Ioldtime) = to_days(now());
                //SELECT* FROM Information WHERE TO_DAYS(NOW()) - TO_DAYS(Ioldtime) <= 1
                //SELECT* FROM  Information WHERE YEARWEEK(date_format(Ioldtime, '%Y-%m-%d')) = YEARWEEK(now())
                //infomation = dbContext.Information.FirstOrDefault(a => a.Icid == 20001);
                //Console.WriteLine(infomation.Icid);
                //Console.WriteLine(infomation.Ioldtime);
                //       string limit = "";
                //    List<Information> vPersons = new List<Information>();
                //    var mid = 30001;
                //    vPersons= dbContext.Information.FromSql(
                //" SELECT* FROM  Information WHERE TO_DAYS(NOW()) - TO_DAYS(Ioldtime) <= 1 and Imid={0}", mid)
                //.AsNoTracking().ToList();
                //       if (limit == "月")
                //       {
                //            vPersons = dbContext.Information.FromSql(
                //" SELECT* FROM  Information WHERE DATE_FORMAT(Ioldtime, '%Y%m') = DATE_FORMAT(CURDATE(), '%Y%m') and Imid={0}", mid)
                //.AsNoTracking().ToList();
                //       }
                //       else if (limit == "周")
                //       {  //返回一周类该管理员办理的业务    
                //            vPersons = dbContext.Information.FromSql(
                //           "SELECT* FROM  Information WHERE YEARWEEK(date_format(Ioldtime, '%Y-%m-%d')) = YEARWEEK(now()) and Imid={0}", mid).AsNoTracking().ToList();
                //       }
                //       else if (limit == "天")
                //       {
                //           //返回今天的业务办理情况
                //            vPersons = dbContext.Information.FromSql(
                //     "select * from Information where to_days(Ioldtime) = to_days(now()) and Imid={0}", mid).AsNoTracking().ToList();
                //       }
                //       else
                //       {
                //            vPersons = dbContext.Information.FromSql(
                //   "select * from Information where to_days(Ioldtime) = to_days(now()) and Imid={0}", mid).AsNoTracking().Take(10).ToList();
                //       }
                //foreach (var vPerson in vPersons)
                //{
                //    Console.Write(vPerson.Icid + " ");
                //    Console.Write(vPerson.Iuid + " ");
                //    Console.Write(vPerson.Ioldtime + " ");
                //    Console.Write(vPerson.Imid + " ");
                //    Console.WriteLine();
                //}
                //Console.WriteLine($"Information视图有{vPersons.Count.ToString()}行数据");
                //Console.WriteLine(vPersons[0].Icid.ToString());

                #region 计算利息原理
                //时间差值计算利息
                //1.C# DateTime转成MySQL DateTime的字符串：
                //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ////2.MySQL 读出的DateTime转换成C#的DateTime
                //DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(infomation.Ioldtime).ToString("yyyy-MM-dd HH:mm:ss"));
                //Console.WriteLine(infomation.Ioldtime);//查看数据库视图中的旧时间字段
                //DateTime dt2 = System.DateTime.Now;//生成新的系统时间
                //Console.WriteLine(DateTime.Now);//打印现在时间
                ////Double Day = dt2.Day - dt1.Day;//天数差值
                ////Console.WriteLine(Day);
                //Double Month = dt2.Month;
                //Console.WriteLine(Month);
                //Day = Day * 0.2;
                //Console.WriteLine(Day);
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
                        //depositors = dbContext.Depositors.FirstOrDefault(a => a.Uid == 10001);
                        //depositors.Uname = "newName" + (new Random().Next(1, 100));
                        //dbContext.SaveChanges();
                        ////第二个更改数据库操作
                        //var id = 10005;
                        //var cid = 20005;
                        //var sql = @"Update Depositors SET Ucid =  {0} WHERE Uid =  {1}";
                        //dbContext.Database.ExecuteSqlCommand(sql, cid, id);
                        //保存数据



                        //List<Records> record = new List<Records>();
                        //List<Records> records = new List<Records>();
                        ////record = dbContext.Database.ExecuteSqlCommand(sql1);//修改时使用
                        //var cid = 20001;
                        //record = dbContext.Records.FromSql("select * from Records where Rcid={0} order by Rid desc",cid).AsNoTracking().Take(10).ToList();
                        //foreach (var item in record)
                        //{
                        //    Console.Write(item.RnowDateTime);
                        //    Console.WriteLine(item.Rid);
                        //}

                       // var mid = 30001;
                       //var i = 0;
                        //for (int i = 0; i < 12; i++)
                        //{
                            //          record = dbContext.Records.FromSql(
                            //" SELECT* FROM  Records WHERE TO_DAYS(NOW()) - TO_DAYS(RnowDateTime) = {0} and Rmid={1}", i,mid)
                            //.AsNoTracking().ToList();
                            // record = dbContext.Records.FromSql(
                            //"  SELECT* FROM Records WHERE PERIOD_DIFF(date_format(now(), '%Y%m'), date_format(RnowDateTime, '%Y%m')) = {0} and Rmid={1}", i, mid)
                            //.AsNoTracking().ToList();
                            //record = dbContext.Records.FromSql(
                            //"SELECT* FROM Records WHERE YEAR(RnowDateTime) = YEAR(NOW())", i)
                            //.AsNoTracking().ToList();
                            //foreach (var item in record)
                            //{
                            //    records.Add(item);
                            //}
                            //records.Add();
                        //}
                


                        //查询一组对象
                        //List<Bands> bands = new List<Bands>();
                        //bands = dbContext.Bands.FromSql("select * from bands").AsNoTracking().ToList()
                        //foreach (var item in bands)
                        //{
                        //    Console.Write(item.Buid);
                        //    Console.WriteLine(item.Bcid);
                        //}
                        //查询出一个对象
                        //Bands band = new Bands();
                        //band = dbContext.Bands.FromSql("select * from bands where Bcid = 20001").AsNoTracking().ToList().FirstOrDefault();
                        //Console.WriteLine(band.Buid);
                        //dbContext.SaveChanges();
                        //提交，如果不写并不会报错，但是数据库不会更新


                        //User user = new User();
                        //user.Id = 10001;
                        //user.Password = "10002";
                        ////user.Identify = "储户";
                        //depositors = dbContext.Depositors.FromSql("select * from Depositors where  Uid= {0} and Upassword={1} ",
                        //    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();
                        //Console.WriteLine(depositors.Uid);
                        //Console.WriteLine(depositors.Upassword);

                        //User user = new User();
                        //user.Id = 10001;
                        //user.Password = "10002";
                        ////user.Identify = "储户";
                        //depositors = dbContext.Depositors.FromSql("select * from Depositors where  Uid= {0} and Upassword={1} ",
                        //    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();
                        //Console.WriteLine(depositors.Uid);
                        //Console.WriteLine(depositors.Upassword);

                        //dbContext.Add(depositor);
                        //Records record = new Records();
                        //var cid = 20001;
                        ////record = dbContext.Records.FromSql("select * from Records where Rcid={0} And RflowDeposit != 0 or Rwithdrawals != 0 order by Rid desc", cid).AsNoTracking().ToList().FirstOrDefault();
                        //foreach (var item in record)
                        //{
                        //    Console.WriteLine(item.RflowDeposit);
                        //    Console.WriteLine(item.Rwithdrawals);
                        //    Console.WriteLine(item.RnowDateTime);
                        //}
                        //Console.WriteLine(record.RnowDateTime);
                        //Console.WriteLine(record.RflowDeposit);
                        //Console.WriteLine(record.Rwithdrawals);
                        //DateTime dt1 = (DateTime)record.RnowDateTime;
                        ////DateTime dt1 = Convert.ToDateTime(Convert.ToDateTime(infomation.Ioldtime).ToString("yyyy-MM-dd HH:mm:ss"));
                        //DateTime dt2 = System.DateTime.Now;//生成新的系统时间
                        //Double Day = dt2.Day - dt1.Day;//天数差值
                        //Console.WriteLine(Day);
                        //List<Fixbalances> fixbalances = new List<Fixbalances>();
                        //fixbalances = dbContext.Fixbalances.FromSql("select * from Fixbalances where Fcid={0} order by Fid desc", cid).AsNoTracking().ToList();
                        //foreach (var item in fixbalances)
                        //{
                        //    Console.WriteLine(item.Fcid);
                        //    Console.WriteLine(item.FfixBalance);
                        //    Console.WriteLine(item.FfixBalanceRate);
                        //}
                        //Cards records = new Cards();
                        //records.CflowBalanceRate = 0.00325;
                        //records.Cuid = 10001;
                        //records.Cpassword = "20036";
                        //dbContext.Add(records);
                        //dbContext.SaveChanges();


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
