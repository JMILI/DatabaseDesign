using System;
using System.Collections.Generic;

namespace TestBank.SqlBank
{
    public partial class Cards
    {
        public Cards()
        {
            Fixbalances = new HashSet<Fixbalances>();
            Records = new HashSet<Records>();
        }

        public int Cid { get; set; }
        public int Cuid { get; set; }
        public string Cpassword { get; set; }
        public double? CflowBalance { get; set; }
        public double? CflowBalanceRate { get; set; }

        public Depositors Cu { get; set; }
        public Bands Bands { get; set; }
        public ICollection<Fixbalances> Fixbalances { get; set; }
        public ICollection<Records> Records { get; set; }
    }
}
