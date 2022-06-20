using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class message
    {

        /// <summary>
        /// 
        /// </summary>
        public long? ID { get; set; }

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
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string Receiver { get; set; }

        /// <summary>
        /// 消息类型,0:初始,1:成功,2:失败
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 模板编码
        /// </summary>
        public string TplCode { get; set; }

        /// <summary>
        /// 消息类型,0:短信,1:邮件
        /// </summary>
        public string Type { get; set; }

    }
}