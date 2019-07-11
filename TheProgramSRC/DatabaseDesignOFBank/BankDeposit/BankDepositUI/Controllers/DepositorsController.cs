using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankDepositUI.Models;
using BankDeposit.Model.SqlBank;
using BankDeposit.Service;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BankDeposit.Model.Helper;
using System.IO;
using OfficeOpenXml;
using System.Web;
using NPOI.HSSF.UserModel;
using System.Security.Cryptography;
using System.Text;

namespace BankDepositUI.Controllers
{
    public class DepositorsController : Controller
    {
        #region 实例化一些工具对象
        public static DepositorsService depositorServive = new DepositorsService();
        #endregion

        #region “登录”功能 已实现
        /// <summary>
        /// “登录”功能
        /// </summary>
        /// <param name="depositor">传入的是DepositorAndCard类型的数据</param>
        /// <returns>返回主页</returns>
        public IActionResult Login(DepositorAndCard depositor)
        {
            cooikeAdd(depositor);
            return View("Login", depositor);
        }
        #endregion

        #region  “注册储户”功能 已实现
        /// <summary>
        /// 返回页面提供用户填写信息
        /// </summary>
        /// <returns></returns>
        public IActionResult AddInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        /// <summary>
        /// 增加储户，并登录到储户系统
        /// </summary>
        /// <param name="depositor">传入前端页面填写的信息，参数对象Depositors：Uid，Uname，Upassword </param>
        /// <returns></returns>
        public IActionResult AddLogin(Depositors depositor)
        {
            depositor.Upassword=MD5Encrypt64(depositor.Upassword);
            DepositorAndCard depositors = new DepositorAndCard();
            depositors = depositorServive.AddService(depositor);
            if (depositors != null)
            {
                cooikeAdd(depositors);
                return RedirectToAction("Login", "Depositors", depositors);
            }
            else
                return Redirect(Url.Action("DepositoryExistError", "Errors"));
        }
        #endregion

        #region “查询近十笔交易记录”功能 已实现
        /// <summary>
        /// 主要查询记录表中该用户的交易记录,查询前十项记录，该功能要用Ajax，
        /// 所以不需要建一个新的cshtml页面，只需要在Login的页面中加入数据即可。
        /// </summary>
        /// <returns>返回json类型数据，数据为十项记录</returns>
        public ActionResult QueryTenRecords()
        {
            List<Records> record = new List<Records>();
            record = depositorServive.TenRecordsService((int)DAndC().Dcid);//接受查询结果，为Records表的数据，十项记录
            return Content(JsonConvert.SerializeObject(record));//返回Json数据对象，Ajax接受
        }

        #region 记录导出Excel
        public FileResult OutExcel()
        {
            List<Records> record = new List<Records>();
            record = depositorServive.TenRecordsService((int)DAndC().Dcid);
            //创建Excel文件的对象
            HSSFWorkbook book = new HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，
            //推荐：使用NPOI操作Excel导入导出数据
            //使用 NPOI 的优势: 1、你不需要在服务器上安装微软的 Office，可以避免版权问题。 2、使用起来比 Office PIA的 API更加方便，更人性化。 3、你不用去花大力气维
            //但是不是很方便，这里就不设置了
            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("索引");
            row1.CreateCell(1).SetCellValue("单号");
            row1.CreateCell(2).SetCellValue("账户ID");
            row1.CreateCell(3).SetCellValue("银行卡号");
            row1.CreateCell(4).SetCellValue("活期存款额");
            row1.CreateCell(5).SetCellValue("定期存款额");
            row1.CreateCell(6).SetCellValue("取款额");
            row1.CreateCell(7).SetCellValue("交易时间");
            row1.CreateCell(8).SetCellValue("办理员");
            //row1.CreateCell(0).SetCellValue("单号");
            //row1.CreateCell(1).SetCellValue("账户ID");
            //row1.CreateCell(2).SetCellValue("银行卡号");
            //row1.CreateCell(3).SetCellValue("活期存款额");
            //row1.CreateCell(4).SetCellValue("定期存款额");
            //row1.CreateCell(5).SetCellValue("取款额");
            //row1.CreateCell(6).SetCellValue("交易时间");
            //row1.CreateCell(7).SetCellValue("办理员");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < record.Count; i++)
            {
                //创建行
                NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(i + 1);
                rowTemp.CreateCell(0).SetCellValue((i + 1).ToString());
                rowTemp.CreateCell(1).SetCellValue(record[i].Rid);
                rowTemp.CreateCell(2).SetCellValue(record[i].Ruid);
                rowTemp.CreateCell(3).SetCellValue(record[i].Rcid);
                rowTemp.CreateCell(4).SetCellValue((double)record[i].RflowDeposit);
                rowTemp.CreateCell(5).SetCellValue((double)record[i].RfixDepostit);
                rowTemp.CreateCell(6).SetCellValue((double)record[i].Rwithdrawals);
                rowTemp.CreateCell(7).SetCellValue(record[i].RnowDateTime.ToString());
                rowTemp.CreateCell(8).SetCellValue((double)record[i].Rmid);
                //rowTemp.CreateCell(0).SetCellValue(record[i].Rid);
                //rowTemp.CreateCell(1).SetCellValue(record[i].Ruid);
                //rowTemp.CreateCell(2).SetCellValue(record[i].Rcid);
                //rowTemp.CreateCell(3).SetCellValue((double)record[i].RflowDeposit);
                //rowTemp.CreateCell(4).SetCellValue((double)record[i].RfixDepostit);
                //rowTemp.CreateCell(5).SetCellValue((double)record[i].Rwithdrawals);
                //rowTemp.CreateCell(6).SetCellValue(record[i].RnowDateTime.ToString());
                //rowTemp.CreateCell(7).SetCellValue((double)record[i].Rmid);
                //....N行
            }
            // 写入到客户端 
            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "查询结果" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //book.Write(ms);
            //ms.Seek(0, SeekOrigin.Begin);
            //Response.a("Content-Disposition", string.Format("attachment; filename={0}.xls", "****总表" + DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            //Response.BinaryWrite(ms.ToArray());
            //book = null;
            //ms.Close();
            //ms.Dispose();
            //return Content("");
        }
        #endregion

        #endregion

        #region “绑定银行卡”功能 已实现
        /// <summary>
        /// 返回绑定银行卡的填写页面，此功能是绑定银行卡，而不是选绑银行卡
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdataBandInformation()
        {
            return View();
        }
        //2.将返回的信息进行处理，然后登陆系统主页
        /// <summary>
        /// 绑定银行卡并返回主页
        /// </summary>
        /// <param name="depositor">前端传入DepositorAndCard对象，属性：Duid,Dname,Dcid</param>
        /// <returns></returns>
        public IActionResult UpdataBand(DepositorAndCard depositor)
        {
            depositor.Duid = DAndC().Duid;
            depositor.Dname = DAndC().Dname;//从浏览器获取属性值给传进来的depositor
            bool s = depositorServive.UpdataBandService(depositor);//绑定
            if (s == true)
            {
                return RedirectToAction("Login", "Depositors", depositor);
            }
            else
                return Redirect(Url.Action("DepositoryNotExistError", "Errors"));
        }

        #endregion

        #region “查询活期余额”功能 已实现
        public ActionResult FlowBalance()
        {
            List<Double> record = new List<Double>();//double类型的List，存放一个余额，一个利息
            record = depositorServive.FlowBalanceService((int)DAndC().Dcid);//这里需要service返回一个余额，一个利息
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region “查询定期余额”功能 已实现
        public ActionResult FixBalance()
        {
            List<Fixbalances> record = new List<Fixbalances>();
            record = depositorServive.FixBalanceService((int)DAndC().Dcid);//这里需要service返回一个余额，一个利息
            return Content(JsonConvert.SerializeObject(record));//以json方式
        }
        #endregion

        #region 辅助函数：登录，注册功能模块中，加入cooike
        /// <summary>
        /// 向浏览器cooike中加入值DepositorAndCard
        /// </summary>
        /// <param name="card1">传入DepositorAndCard对象</param>
        public void cooikeAdd(DepositorAndCard depositor)
        {
            this.Response.Cookies.Append("Uid", depositor.Duid.ToString());
            this.Response.Cookies.Append("Cid", depositor.Dcid.ToString());
            this.Response.Cookies.Append("Name", depositor.Dname.ToString());
        }
        /// <summary>
        /// 从浏览器获取DepositorAndCard对象的值：Dcid，Dname，Duid
        /// </summary>
        /// <returns>返回DepositorAndCard对象</returns>
        public DepositorAndCard DAndC()
        {
            DepositorAndCard dAndC = new DepositorAndCard();
            this.Request.Cookies.TryGetValue("Cid", out string Cid);
            int cid = int.Parse(Cid);
            this.Request.Cookies.TryGetValue("Uid", out string Uid);
            int uid = int.Parse(Uid);
            this.Request.Cookies.TryGetValue("Name", out string Name);
            string name = Name;
            dAndC.Dcid = cid;
            dAndC.Dname = name;
            dAndC.Duid = uid;
            return dAndC;
        }
        #endregion

        #region 辅助函数MD5加密用户密码
        /// <summary>
        /// MD5加密用户密码
        /// </summary>
        /// <param name="password"> 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　</param>
        /// <returns></returns>
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        #endregion

    }
}
