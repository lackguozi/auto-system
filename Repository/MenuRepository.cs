using LuckCode.IRepository;
using LuckCode.Model;
using LuckCode.Repository.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository
{
    public class MenuRepository : BaseRepository<sysmenu>, IMenuRepository
    {
        private readonly IUnitOfWorkManger unitOfWorkManger;

        public MenuRepository(IUnitOfWorkManger unitOfWorkManger) : base(unitOfWorkManger)
        {
            this.unitOfWorkManger = unitOfWorkManger;
        }
        /// <summary>
        /// 根据角色查找用户左侧权限目录
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="enabledOnly"></param>
        /// <returns></returns>
        public async Task<List<sysmenu>> GetMenusByRoleIds(long[] roleIds, bool enabledOnly)
        {
            
            var query = await base.DbContext().Queryable<sysrelation>().LeftJoin<sysmenu>((r, m) => r.MenuId == m.ID).Where(r => roleIds.Contains(r.RoleId)).Select((r, m) => m).Distinct().ToListAsync();
            return   query;
        }
    } 
}
