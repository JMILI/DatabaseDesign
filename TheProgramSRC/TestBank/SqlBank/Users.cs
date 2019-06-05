using System;
using System.Collections.Generic;

namespace TestBank.SqlBank
{
    public partial class Users
    {
        public Users()
        {
            Cards = new HashSet<Cards>();
        }

        public int Uid { get; set; }
        public int? Ucid { get; set; }
        public string Uname { get; set; }
        public string Upassword { get; set; }
        public string Ustatus { get; set; }

        public ICollection<Cards> Cards { get; set; }
    }
}
