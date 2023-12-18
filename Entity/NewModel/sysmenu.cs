using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SqlSugar;

namespace LuckCode.Model
{
    public class sysmenu
    {

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long ID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreateBy { get; set; }

        /// <summary>
        /// 创建时间/注册时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public long? ModifyBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 組件配置
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public Boolean? Hidden { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否是菜单1:菜单,0:按钮
        /// </summary>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 是否默认打开1:是,0:否
        /// </summary>
        public bool? IsOpen { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int? Levels { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int? Num { get; set; }

        /// <summary>
        /// 父菜单编号
        /// </summary>
        public string PCode { get; set; }

        /// <summary>
        /// 递归父级菜单编号
        /// </summary>
        public string PCodes { get; set; }

        /// <summary>
        /// 状态1:启用,0:禁用
        /// </summary>
        public Boolean? Status { get; set; }

        /// <summary>
        /// 鼠标悬停提示信息
        /// </summary>
        public string Tips { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

    }
}