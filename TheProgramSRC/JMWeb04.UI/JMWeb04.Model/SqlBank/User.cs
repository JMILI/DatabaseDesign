using System;
using System.Collections.Generic;
using System.Text;

namespace JMWeb04.Model.SqlBank
{
    class User
    {
        //登录页面需要一个容器，这个可以代表储户或者管理员
        public int Id { get; set; }
        public string Password { get; set; }
        public string Identity { get; set; }
    }
}
