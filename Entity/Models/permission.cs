using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class permission
    {

        /// <summary>
        /// 权限编号
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 父权限ID
        /// </summary>
        public Int64? parent_id { get; set; }

        /// <summary>
        /// 父权限名称
        /// </summary>
        public string parent_name { get; set; }

        /// <summary>
        /// 授权标识符
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 路由名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 授权路径
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 权限类型(0-目录 1-菜单 2-按钮)
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? create_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? update_time { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? order_num { get; set; }

        /// <summary>
        /// 是否删除(0-未删除，1-已删除)
        /// </summary>
        public int? is_delete { get; set; }

    }
}