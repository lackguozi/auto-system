using LuckCode.IServices.Base;
using LuckCode.Model;
using LuckCode.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.IServices
{
    public interface IDeptService: IBaseService<sysdept>
    {
        Task<List<DeptNode>> GetDeptList();
        Task<List<DeptNode>> GetParDeptList();
        Task<bool> AddDept(SysDeptDto deptNode);
    }
}
