using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class user
    {

        /// <summary>
        /// 用户编号
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 登录名称(用户名)
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 帐户是否过期(1-未过期，0-已过期)
        /// </summary>
        public int? is_account_non_expired { get; set; }

        /// <summary>
        /// 帐户是否被锁定(1-未过期，0-已过期)
        /// </summary>
        public int? is_account_non_locked { get; set; }

        /// <summary>
        /// 密码是否过期(1-未过期，0-已过期)
        /// </summary>
        public int? is_credentials_non_expired { get; set; }

        /// <summary>
        /// 帐户是否可用(1-可用，0-禁用)
        /// </summary>
        public int? is_enabled { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string real_name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        public Int64? department_id { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// 性别(0-男，1-女)
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 是否是管理员(1-管理员)
        /// </summary>
        public int? is_admin { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? create_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? update_time { get; set; }

        /// <summary>
        /// 是否删除(0-未删除，1-已删除)
        /// </summary>
        public int? is_delete { get; set; }

    }
}