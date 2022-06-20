using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SqlSugar;

namespace LuckCode.Model
{
    public class sysrole
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
        /// 
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Pid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tips { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Version { get; set; }

    }
}