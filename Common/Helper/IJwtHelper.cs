using LuckCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Common.Helper
{
    public interface IJwtHelper
    {
        string GetJWTToken(sysuser user);
    }
}
