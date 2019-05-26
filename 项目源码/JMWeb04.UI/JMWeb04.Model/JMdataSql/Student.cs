using System;
using System.Collections.Generic;

namespace JMWeb04.Model.JMdataSql
{
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ClassCode { get; set; }
    }
}
