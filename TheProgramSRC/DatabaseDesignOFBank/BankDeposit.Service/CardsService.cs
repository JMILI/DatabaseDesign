using BankDeposit.Data;
using BankDeposit.Model.SqlBank;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using BankDeposit.Model.Helper;
using System.Linq;
using System.Text;

namespace BankDeposit.Service
{
    public class CardsService
    {
        #region 实例化一些工具对象
        public static AccessCards CardsAccess = new AccessCards();
        public static AccessDepositors DepositorsAccess = new AccessDepositors();
        public static RecordsService recordsService = new RecordsService();
        public static CardsService cardServive = new CardsService();
        #endregion

        #region 查询卡登录
        /// <summary>
        /// 查询卡通过传入的User查询。User：Id,Password,Identify
        /// </summary>
        /// <param name="user">传入登录信息，账号Id,Password,Identify</param>
        /// <returns></returns>
        public DepositorAndCard QueryCardsService(User user)
        {
            DepositorAndCard cards = new DepositorAndCard();//函数将要返回的对象
            Cards card = new Cards();//接受查询结果数据
            Depositors depositor = new Depositors();//接受查询结果数据
            card = CardsAccess.QueryCardsData(user);
            if (card != null)//查询不空
            {
                if (card.Cid != user.Id)//不是要查询的对象
                {
                    cards = null;
                }
                else
                {
                    cards.Duid = card.Cuid;//返回对象装入值
                    cards.Dcid = card.Cid;
                    depositor = DepositorsAccess.CheakData(card.Cuid);//查询该银行卡账户的对应储户
                    cards.Dname = depositor.Uname;
                }
            }
            else
            {
                cards = null;
            }
            return cards;
        }
        #endregion

        #region 取钱
        /// <summary>
        /// ATM活期取款功能
        /// </summary>
        /// <param name="dAndC"></param>
        /// <param name="identity">传入操作类型，此处为1，为取款</param>
        /// <param name="money">传入取钱金额</param>
        /// <returns></returns>
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

        /// <summary>
        /// 记录表Records中增加记录，业务逻辑层,CardsService对象将任务交给recordsService来处理
        /// </summary>
        /// <param name="dAndC">传入从cooike中获取的储户和储户银行卡信息。其对象为DepositorAndCard</param>
        /// <param name="v">出入参数v代表类型,1：代表取款，2：代表活期存款，其他：代表定期存款。每次传入一个类型的值，其他两项字段默认为0</param>
        /// <param name="money">金额</param>
        /// <param name="mid">业务办理员</param>
        public void AddRecords(DepositorAndCard dAndC, int v, double money)
        {
            //此处零代表的是记录表中Mid填为0，代表取款是在ATM中进行的。
            recordsService.AddRecordsService(dAndC, v, money, 0);
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
                DateTime dt1 = recordsService.RecordsTimeData(cid);//从records表中取得上次对活期存款操作的最后时间
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

        #region 注册银行卡
        /// <summary>
        /// 注册银行卡 业务逻辑层，是CardsService类的函数
        /// </summary>
        /// <param name="card">前端页面填写的信息：CflowBalanceRate，Cpassword，Cuid</param>
        internal void AddCardService(Cards card)
        {
            CardsAccess.Add(card);
        }
        #endregion

        #region 查询银行卡信息
        /// <summary>
        /// 查询银行卡信息,根据银行卡账号查询
        /// </summary>
        /// <param name="cid">传入卡号cid</param>
        /// <returns></returns>
        public Cards CheakCards(int cid)
        {
            return CardsAccess.CardsData(cid);
        }
        #endregion

        #region 更新银行卡活期存款余额
        /// <summary>
        /// 更新银行卡活期存款余额
        /// </summary>
        /// <param name="card">传入修改后的银行卡信息</param>
        internal void UpdataFlowBalanceService(Cards card)
        {
            CardsAccess.UpdateCards(card.Cid, (double)card.CflowBalance);
        } 
        #endregion

        #region 查询事项交易记录
        /// <summary>
        /// CardsService层用来查询前十项交易记录的函数,向AccessCards对象发送请求。
        /// </summary>
        /// <param name="cid">传入从cooike中查询的cid</param>
        /// <returns>返回一个根据储户当前默认银行卡的交易记录，取前十项</returns>
        internal List<Records> TenRecordsService(int cid)
        {
            return CardsAccess.TenRecordsData(cid);
        }
        #endregion
    }
}
