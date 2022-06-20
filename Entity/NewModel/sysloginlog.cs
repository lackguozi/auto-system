using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class sysloginlog
    {

        /// <summary>
        /// 
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Succeed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? UserId { get; set; }

    }
}