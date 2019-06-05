using System;
using System.Collections.Generic;
using System.Text;

namespace TestBank.SqlBank
{
    class Information
    {
        public int Icid { get; set; }
        public int Iuid { get; set; }
        public DateTime? Ioldtime { get; set; }
        public double IflowBalance { get; set; }
        public double IfixBalance { get; set; }
        public string Iname { get; set; }
        public string Istatus { get; set; }
    }
}
