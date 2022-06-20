﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Model.Dto
{
    public class UserInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 用户个人信息
        /// </summary>
        public UserProfile Profile { get; set; }

        /// <summary>
        /// 角色集合
        /// </summary>
        public List<string> Roles { get; private set; } = new List<string>();

        /// <summary>
        /// 权限集合
        /// </summary>
        public List<string> Permissions { get; private set; } = new List<string>();
    }
}
