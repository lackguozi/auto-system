using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckCode.IRepository.Base;
using LuckCode.Model;

namespace LuckCode.IRepository
{
    public interface IMenuRepository:IBaseRepository<sysmenu>
    {
        Task<List<sysmenu>> GetMenusByRoleIds(long[] roleIds, bool enabledOnly);
    }
}
