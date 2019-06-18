using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;

namespace BankDeposit.Data
{
    /// <summary>
    /// 此类用于ATM系统访问数据
    /// </summary>
    public class AccessCards
    {
        public static Cards card = new Cards();

        #region 查询银行卡（登录的）
        public Cards QueryCardsData(User user)
        {
            using (var dbContext = new bankContext())
            {
                card = dbContext.Cards.FromSql("select * from Cards where  Cid= {0} and Cpassword={1} ",
                    user.Id, user.Password).AsNoTracking().ToList().FirstOrDefault();
                return card;
            }
            //return access.QueryCardsData(user);
        }
        #endregion
        #region 查询银行卡
        public Cards CardsData(int? cid)
        {
            using (var dbContext = new bankContext())
            {
                return  dbContext.Cards.FirstOrDefault(a => a.Cid == cid);
            }
        }
        #endregion
        #region 查询前十项记录
        /// <summary>
        /// 查询最近十项记录,
        /// </summary>
        /// <returns></returns>
        public List<Records> TenRecordsData(int cid)
        {
            using (bankContext dbContext = new bankContext())
            {
                //通过ViewContext.Iformation属性从数据库中查询视图数据，因为和数据库表不同，
                //我们不会更新数据库视图的数据，所以调用AsNoTracking方法来告诉EF Core不用在DbContext中跟踪返回的Iformation实体，可以提高EF Core的运行效率
                return dbContext.Records.FromSql("select * from Records where Rcid={0} order by Rid desc", cid).AsNoTracking().Take(10).ToList();
            }
        }
        #endregion
    }
}
