using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Book
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int id { get; private set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string title { get; private set; }

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