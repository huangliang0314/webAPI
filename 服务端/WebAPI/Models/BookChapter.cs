using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    [XmlRoot]
    public class BookChapter
    {
        [XmlElement]
        /// <summary>
        /// 章节序号
        /// </summary>
        public int Number { get; set; }


        /// <summary>
        /// 章节标题
        /// </summary>
        [XmlAttribute]
        public string Title { get; set; }

        [XmlElement]
        /// <summary>
        /// 章节页号
        /// </summary>
        public int Pages { get; set; }

    }
}
