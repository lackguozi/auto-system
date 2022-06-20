using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Model
{
    public class ModuleInfo
    {
        public string Id { get; set; }
        public string Version { get; set; }

        public Assembly Assembly { get; set; }
    }
}
