using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Model.Dto
{
    /// <summary>
    /// 菜单路由
    /// </summary>
    public class RouteMenu
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 菜编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 父菜单编码
        /// </summary>
        public string PCode { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 菜单对应视图组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单排序
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// 菜单元数据
        /// </summary>
        public MenuMeta Meta { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<RouteMenu> Children { get; private set; } = new List<RouteMenu>();
    }
}
