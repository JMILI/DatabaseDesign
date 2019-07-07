using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    public partial class Fixbalances
    {
        public int Fid { get; set; }
        public int Fcid { get; set; }
        public int? Fyear { get; set; }
        public double? FfixBalanceRate { get; set; }
        public double? FfixBalance { get; set; }
        public DateTime? FbusinessTime { get; set; }
        public int? Fmid { get; set; }
    }
}
