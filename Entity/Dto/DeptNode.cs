using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Model.Dto
{
    public class DeptNode:SysDeptDto
    {
        public string parentName { get; set; }
        public bool open { get; set; }=false;
        public List<DeptNode> Children { get; private set; } = new List<DeptNode>();
    }
}
