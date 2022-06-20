using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LuckCode.Model
{
    public class cmsarticle
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
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 栏目id
        /// </summary>
        public long? IdChannel { get; set; }

        /// <summary>
        /// 文章题图ID
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

    }
}