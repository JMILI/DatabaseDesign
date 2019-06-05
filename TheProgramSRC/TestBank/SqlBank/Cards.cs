using System;
using System.Collections.Generic;

namespace TestBank.SqlBank
{
    public partial class Cards
    {
        public Cards()
        {
            Records = new HashSet<Records>();
        }

        public int Cid { get; set; }
        public int? Cuid { get; set; }
        public string Cpassword { get; set; }
        public double? CflowBalance { get; set; }
        public double? CfixBalance { get; set; }

        public Users Cu { get; set; }
        public ICollection<Records> Records { get; set; }
    }
}
