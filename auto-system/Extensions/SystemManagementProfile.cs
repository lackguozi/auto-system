using AutoMapper;
using LuckCode.Model;
using LuckCode.Model.Dto;

namespace auto_system.Extensions
{
    public class SystemManagementProfile : Profile
    {
        public SystemManagementProfile()
        {
            /*CreateMap(typeof(IPagedListResult<>), typeof(PagedModel<>));
            CreateMap(typeof(ZTreeNode<,>), typeof(Node<>)).IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<SysCfg, SysCfgDto>().ReverseMap();
            CreateMap<SysDept, SysDeptDto>().ReverseMap();
            CreateMap<SysDept, DeptNode>();
            CreateMap<SysDict, SysDictDto>().ReverseMap();
            CreateMap<SysFileInfo, SysFileInfoDto>().ReverseMap();
            CreateMap<SysLoginLog, SysLoginLogDto>().ReverseMap();
            CreateMap<SysMenu, SysMenuDto>().ReverseMap();
            CreateMap<SysMenu, RouterMenu>();
            CreateMap<SysMenu, MenuNode>();
            CreateMap<SysNotice, SysNoticeDto>().ReverseMap();
            CreateMap<SysOperationLog, SysOperationLogDto>().ReverseMap();
            CreateMap<SysRelation, SysRelationDto>().ReverseMap();
            CreateMap<SysRole, SysRoleDto>().ReverseMap();
            CreateMap<SysTask, SysTaskDto>().ReverseMap();
            CreateMap<SysTaskLog, SysTaskLogDto>().ReverseMap();*/
            CreateMap<sysuser, SysUserDto>().ReverseMap();
            CreateMap<sysuser, UserProfile>();
            CreateMap<sysmenu, RouteMenu>();
            CreateMap<sysdept, SysDeptDto>().ReverseMap();
            CreateMap<sysdept, DeptNode>();
        }
    }
}
