using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Common
{
    /// <summary>
    /// 当前用户上下文
    /// </summary>
    public class UserContext
    {
        public long id { get; set; }

        public string name { get; set; }     

        public string Email { get; set; }

        public string role { get; set; }
    }
}
