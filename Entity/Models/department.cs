using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SqlSugar;
namespace LuckCode.Model
{
    public class department
    {

        /// <summary>
        /// 部门编号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long? id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// 部门电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 部门地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 所属部门编号
        /// </summary>
        public long? pid { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string parent_name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? order_num { get; set; }

        /// <summary>
        /// 是否删除(0-未删除 1-已删除)
        /// </summary>
        public int? is_delete { get; set; }

    }
}