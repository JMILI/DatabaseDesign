using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    public partial class Cards
    {
        public int Cid { get; set; }
        public int Cuid { get; set; }
        public string Cpassword { get; set; }
        public double? CflowBalance { get; set; }
        public double? CflowBalanceRate { get; set; }

        public Depositors Cu { get; set; }
    }
}
