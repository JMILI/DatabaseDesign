using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    public partial class Depositors
    {
        public Depositors()
        {
            Records = new HashSet<Records>();
        }

        public int Uid { get; set; }
        public int? Ucid { get; set; }
        public string Uname { get; set; }
        public string Upassword { get; set; }
        public string Uidentify { get; set; }
        public string Ustatus { get; set; }

        public ICollection<Records> Records { get; set; }
    }
}
