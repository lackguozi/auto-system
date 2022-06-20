using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class role
    {

        /// <summary>
        /// 角色编号
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string role_code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long? create_user { get; set; }

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
        /// 是否删除(0-未删除，1-已删除)
        /// </summary>
        public int? is_delete { get; set; }

    }
}