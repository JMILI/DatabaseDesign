using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDeposit.Service
{
    public class CardsService
    {
        #region 实例化一些工具对象
        public static AccessCards CardsAccess = new AccessCards();
        public static AccessDepositors DepositorsAccess = new AccessDepositors();
        public static AccessRecords accessRecord = new AccessRecords();
        public static RecordsService recordsService = new RecordsService();
        public static CardsService cardServive = new CardsService();
        #endregion

        #region 查询卡登录
        public DepositorAndCard QueryCardsService(User user)
        {
            DepositorAndCard cards = new DepositorAndCard();
            Cards card = new Cards();
            Depositors depositor = new Depositors();
            card = CardsAccess.QueryCardsData(user);
            if (card != null)
            {
                if (card.Cid != user.Id)
                {
                    cards = null;
                }
                else
                {
                    cards.Duid = card.Cuid;
                    cards.Dcid = card.Cid;
                    depositor = DepositorsAccess.CheakData(card.Cuid);
                    cards.Dname = depositor.Uname;
                }
            }
            else
            {
                cards = null;
            }
            return cards;
        }

        public bool Drawal(DepositorAndCard dAndC, int identity, double money)
        {
            List<Double> record = new List<Double>();
            record = FlowBalanceService((int)dAndC.Dcid);//查询银行卡活期的余额
            if (record[1] >= money)//可取
            {
                //1.修改卡的表项，//取钱，
                AddRecords(dAndC, identity, money);
                money = record[1] - money;//使用计算的余额减去要取余额。
                CardsAccess.UpdateCards((int)dAndC.Dcid, money);//更新余额
                return true;
            }
            else return false;//不可取
        }

        public void AddRecords(DepositorAndCard dAndC, int v, double money)
        {
            //此处零代表的是记录表中Mid填为0，代表取款是在ATM中进行的。
            recordsService.AddRecords(dAndC, v, money, 0);
        }




        #endregion

        #region 银行卡计算利息和余额
        /// <summary>
        /// 是CardsService的方法，银行卡计算利息和余额，没有更新数据库功能。只负责查询
        /// </summary>
        /// <param name="cid">那个卡？</param>
        /// <returns>返回计算后的余额，和利息</returns>
        public List<double> FlowBalanceService(int cid)
        {
            Cards card = new Cards();
            card = CardsAccess.CardsData(cid);
            if (card != null)
            {
                //计算利息
                List<Double> record = new List<Double>();

                var balance = (double)card.CflowBalance;//取得卡表中活期现有存款
                var rate = card.CflowBalanceRate / 360;//取得相应利率
                DateTime dt1 = (DateTime)accessRecord.RecordsTimeData(cid);//从records表中取得上次对活期存款操作的最后时间
                DateTime dt2 = System.DateTime.Now;//生成新的系统时间
                Double Day = dt2.Day - dt1.Day;//天数差值
                var rates = (double)rate * Day * balance;//计算利息
                balance = rates + balance;
                //list表中加入我们要返回的数据
                record.Add(rates);
                record.Add(balance);
                return record;
            }
            else return null;
        }

        #endregion

        internal void AddCardService(Cards card)
        {
            CardsAccess.Add(card);
        }

        public Cards CheakCards(int cid)
        {
            return CardsAccess.CardsData(cid);
        }
        internal void UpdataFlowBalanceService(Cards card)
        {
            CardsAccess.UpdateCards(card.Cid, (double)card.CflowBalance);
        }
    }
}
