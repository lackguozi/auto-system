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
            //Console.WriteLine(currentUser.id);
            //找出用户详细信息
            var user = await base.QueryByID(currentUser.id);
            //找出用户部门信息
            //var dept = await base.qu
            UserInfo userContext = new UserInfo()
            {
                Name = user.Name,
                Role = "admin"
            };
            //用户个人信息
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

        public async Task<List<RouteMenu>> GetMenuList()
        {
            List<RouteMenu> menuList = new List<RouteMenu>();
            Console.WriteLine(currentUser.role);
            var roleids = currentUser.role.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => long.Parse(a));
            var menus = await menuRepository.GetMenusByRoleIds(roleids.ToArray(), true);
            if (menus.Count > 0)
            {
                var routeMenus = new List<RouteMenu>();
                foreach (var menu in menus)
                {
                    if (string.IsNullOrEmpty(menu.Component))
                    {
                        continue;
                    }
                    var routeMenu = _mapper.Map<RouteMenu>(menu);
                    routeMenu.Path = menu.Url;
                    routeMenu.Meta = new MenuMeta
                    {
                        Icon = menu.Icon,
                        Title = menu.Name
                    };
                    routeMenus.Add(routeMenu);
                }
                foreach(var node in routeMenus)
                {
                    var parentNode = routeMenus.FirstOrDefault(x=>x.Code==node.PCode);
                    if (parentNode != null)
                    {
                        node.ParentId = parentNode.ID;
                    }
                }
                var dictNodes = routeMenus.ToDictionary(x => x.ID);
                foreach(var pair in dictNodes.OrderBy(x => x.Value.Num))
                {
                    var currNode = pair.Value;
                    //如果找到了父级菜单，那么加入父级菜单的子菜单
                    if(currNode.ParentId.HasValue && dictNodes.ContainsKey(currNode.ParentId.Value))
                    {
                        dictNodes[currNode.ParentId.Value].Children.Add(currNode);
                    }
                    else
                    {
                        //一定是最上面的菜单，前提是维护的菜单数据是完整的
                        menuList.Add(currNode);
                    }
                }
            }
            return menuList;
            

        }
    }
}
