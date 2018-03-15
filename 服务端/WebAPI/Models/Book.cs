using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XmlConfiguration;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    [XmlRoot]
    public class Book
    {
        
        /// <summary>
        /// 序号
        /// </summary>
        [XmlElement]
        public int id { get; private set; }

        [XmlElement]
        /// <summary>
        /// 书名
        /// </summary>
        public string title { get; private set; }

        [XmlElement]
        public ICollection<BookChapter> chapters { get; private set; }

        public Book()
        {

        }

        public Book(int id, string title, params BookChapter[] chapters)
        {
            this.id = id;
            this.title = title;
            this.chapters = chapters.ToList();
        }

    }
}