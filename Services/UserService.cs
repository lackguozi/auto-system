using AutoMapper;
using LuckCode.Common;
using LuckCode.IRepository;
using LuckCode.IRepository.Base;
using LuckCode.IServices;
using LuckCode.Model;
using LuckCode.Model.Dto;
using LuckCode.Services.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Services
{
    public class UserService : BaseService<sysuser>, IUserService
    {
        private readonly UserContext currentUser;
        private readonly IBaseRepository<sysrole> rolebaseRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IMapper _mapper;

        

        public UserService(IBaseRepository<sysuser> baseRepository,UserContext currentUser, IMapper mapper,IBaseRepository<sysrole> rolebaseRepository, IMenuRepository menuRepository) : base(baseRepository)
        {
            this.currentUser = currentUser;
            _mapper = mapper;
            this.rolebaseRepository = rolebaseRepository;
            this.menuRepository = menuRepository;
        }
        public async Task<UserInfo> GetCurrentUserInfo()
        {
            Console.WriteLine(currentUser.id);
            //找出用户详细信息
            var user = await base.QueryByID(currentUser.id);
            //找出用户部门信息
            //var dept = await base.qu
            UserInfo userContext = new UserInfo()
            {
                Name = user.Name,
                Role = "admin"
            };
            userContext.Profile = _mapper.Map<UserProfile>(user);
            userContext.Profile.Dept = "测试部门";
            if (!string.IsNullOrEmpty(user.RoleId))
            {
                var rolesId = user.RoleId.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => long.Parse(a)).ToArray();
                var roles = await rolebaseRepository.QueryByIDs(rolesId);
                foreach(var role in roles)
                {
                    userContext.Roles.Add(role.Tips);
                    userContext.Profile.Roles.Add(role.Name);
                }
                var roleMenus = await menuRepository.GetMenusByRoleIds(rolesId.ToArray(), true);
                if (roleMenus.Any())
                {
                    userContext.Permissions.AddRange(roleMenus.Where(a => a.Url !=null).Select(a => a.Url).Distinct());
                }
            }
            return userContext;
        }
    }
}
