using System;
using System.Collections.Generic;

namespace BankDeposit.Model.SqlBank
{
    public partial class Bands
    {
        public int Bcid { get; set; }
        public int Buid { get; set; }

        public Cards Bc { get; set; }
    }
}
