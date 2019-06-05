using System;
using System.Collections.Generic;

namespace JMWeb04.Model.SqlBank
{
    public partial class Records
    {
        public int Rid { get; set; }
        public int? Ruid { get; set; }
        public int? Rcid { get; set; }
        public float? RflowDeposit { get; set; }
        public float? RfixDepostit { get; set; }
        public DateTime? RnowDateTime { get; set; }

        public Cards Rc { get; set; }
    }
}
