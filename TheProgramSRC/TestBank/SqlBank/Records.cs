using System;
using System.Collections.Generic;

namespace TestBank.SqlBank
{
    public partial class Records
    {
        public int Rid { get; set; }
        public int? Ruid { get; set; }
        public int? Rcid { get; set; }
        public double? RflowDeposit { get; set; }
        public double? RfixDepostit { get; set; }
        public DateTime? RnowDateTime { get; set; }

        public Cards Rc { get; set; }
    }
}
