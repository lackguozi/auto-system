using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class sysoperationlog
    {

        /// <summary>
        /// 
        /// </summary>
        public long? ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Method { get; set; }

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