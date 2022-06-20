using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class systasklog
    {

        /// <summary>
        /// 
        /// </summary>
        public long? ID { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime? ExecAt { get; set; }

        /// <summary>
        /// 执行结果（成功:1、失败:0)
        /// </summary>
        public Boolean? ExecSuccess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? IdTask { get; set; }

        /// <summary>
        /// 抛出异常
        /// </summary>
        public string JobException { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        public string Name { get; set; }

    }
}