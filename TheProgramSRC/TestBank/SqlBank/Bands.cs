using System;
using System.Collections.Generic;

namespace TestBank.SqlBank
{
    public partial class Bands
    {
        public int Bcid { get; set; }
        public int Buid { get; set; }

        public Cards Bc { get; set; }
    }
}
