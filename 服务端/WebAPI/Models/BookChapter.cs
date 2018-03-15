using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class BookChapter
    {
        /// <summary>
        /// 章节序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 章节标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 章节页号
        /// </summary>
        public int Pages { get; set; }

    }
}
