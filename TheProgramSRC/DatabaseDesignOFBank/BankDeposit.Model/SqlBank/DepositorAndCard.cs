using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    //此类用来封装储户和储户默认银行卡的一个数据库视图
    public partial class DepositorAndCard
    {
        public int Duid { get; set; }
        public int Dcid { get; set; }
        public string Dname { get; set; }
    }
}

