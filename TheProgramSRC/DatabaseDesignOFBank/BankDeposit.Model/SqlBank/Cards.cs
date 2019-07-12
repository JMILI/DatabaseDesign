using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    public partial class Cards
    {
        public Cards()
        {
            Fixbalances = new HashSet<Fixbalances>();
            Records = new HashSet<Records>();
            TransferrecordsTpartyAc = new HashSet<Transferrecords>();
            TransferrecordsTpartyBc = new HashSet<Transferrecords>();
        }

        public int Cid { get; set; }
        public int Cuid { get; set; }
        public string Cpassword { get; set; }
        public double? CflowBalance { get; set; }
        public double? CflowBalanceRate { get; set; }

        public ICollection<Fixbalances> Fixbalances { get; set; }
        public ICollection<Records> Records { get; set; }
        public ICollection<Transferrecords> TransferrecordsTpartyAc { get; set; }
        public ICollection<Transferrecords> TransferrecordsTpartyBc { get; set; }
    }
}
