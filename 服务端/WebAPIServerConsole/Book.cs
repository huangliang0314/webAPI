using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XmlConfiguration;
using System.Xml.Serialization;

namespace WebAPIServerConsole
{
    
    [Serializable]
    [XmlSerializerAssembly("hl")]
    [XmlRoot]
    public class Book
    {
        [XmlElement]
        /// <summary>
        /// 序号
        /// </summary>
        public int id { get; private set; }

        [XmlElement]
        /// <summary>
        /// 书名
        /// </summary>
        public string title { get; private set; }

       

        public Book()
        {

        }

        public Book(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

    }
}