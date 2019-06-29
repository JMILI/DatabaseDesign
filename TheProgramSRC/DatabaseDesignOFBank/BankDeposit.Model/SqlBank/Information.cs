using System;
using System.Collections.Generic;
using System.Text;

namespace BankDeposit.Model.SqlBank
{
   public class Information
    {
        public int Irid { get; set; }
        public string Iname { get; set; }
        public int Iuid { get; set; }
        public int Icid { get; set; }
        public double IflowDeposit { get; set; }
        public double IfixDepostit { get; set; }
        public double Iwithdrawals { get; set; }
        public DateTime? Ioldtime { get; set; }
        public int Imid { get; set; }
    }
}
