using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using BankDeposit.Model.Helper;

namespace BankDeposit.Data
{
    /// <summary>
    /// 访问视图Information类
    /// </summary>
    public class AccessInformation
    {
        #region 查询管理员一段时间的办理业务记录
        /// <summary>
        /// 查询管理员一段时间的办理业务记录
        /// </summary>
        /// <param name="mid">传入管理员账号，用来查找它的记录</param>
        /// <param name="limit">传入范围，今天，本周，本月</param>
        /// <returns></returns>
        public List<Information> BusinessData(int mid, string limit)
        {
            if (limit == null) limit = "0";//搜索信息如果为空，令其为字符0.可以跳至最后一个判断情况。
            using (ViewContext dbContext = new ViewContext())
            {
                if (limit.Contains("月"))
                {//返回本月类该管理员办理的业务    
                    return dbContext.Information.FromSql(
         " SELECT* FROM  Information WHERE DATE_FORMAT(Ioldtime, '%Y%m') = DATE_FORMAT(CURDATE(), '%Y%m') and Imid={0}", mid)
         .AsNoTracking().ToList();
                }
                else if (limit.Contains("周"))
                {  //返回一周类该管理员办理的业务    
                    return dbContext.Information.FromSql(
                    "SELECT* FROM  Information WHERE YEARWEEK(date_format(Ioldtime, '%Y-%m-%d')) = YEARWEEK(now()) and Imid={0}", mid).AsNoTracking().ToList();
                }
                else if (limit.Contains("天"))
                {
                    //返回今天的业务办理情况
                    return dbContext.Information.FromSql(
              "select * from Information where to_days(Ioldtime) = to_days(now()) and Imid={0}", mid).AsNoTracking().ToList();
                }
                else
                {
                    //默认返回今天的十项记录
                    return dbContext.Information.FromSql(
              "select * from Information where to_days(Ioldtime) = to_days(now()) and Imid={0}", mid).AsNoTracking().Take(10).ToList();
                }
            }
        }
        #endregion

    }
}
