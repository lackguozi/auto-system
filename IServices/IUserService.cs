﻿using LuckCode.IServices.Base;
using LuckCode.Model;
using LuckCode.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.IServices
{
    public interface IUserService: IBaseService<sysuser>
    {
        Task<UserInfo> GetCurrentUserInfo();
        Task<List<RouteMenu>> GetMenuList();
    }
}
