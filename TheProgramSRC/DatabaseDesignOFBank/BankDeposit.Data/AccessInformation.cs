using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    public class AccessInformation
    {
        #region 查询前十项记录
        /// <summary>
        /// 查询最近十项记录,
        /// </summary>
        /// <returns></returns>
        public List<Information> BusinessData(int mid, string limit)
        {
            using (ViewContext dbContext = new ViewContext())
            {
                if (limit.Contains("月"))
                {
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
                    return dbContext.Information.FromSql(
              "select * from Information where to_days(Ioldtime) = to_days(now()) and Imid={0}", mid).AsNoTracking().Take(10).ToList();
                }
            }
        }
        #endregion

    }
}
