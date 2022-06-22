using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Model.Dto
{
    public class DeptNode:SysDeptDto
    {
        public List<DeptNode> Children { get; private set; } = new List<DeptNode>();
    }
}
