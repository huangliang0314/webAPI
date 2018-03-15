using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // [RoutePrefix("books")]
    public class BookChaptersArrController : ApiController
    {
        private static List<Book> books;
        private static List<BookChapter> chapters;

        static BookChaptersArrController()
        {
            chapters = new List<BookChapter>() {
                new BookChapter(){Number=1,Title="1",Pages=1 },
                new BookChapter(){Number=2,Title="2",Pages=2 },
                new BookChapter(){Number=3,Title="3",Pages=3 },
                new BookChapter(){Number=4,Title="4",Pages=4 },
                new BookChapter(){Number=5,Title="5",Pages=5 },
                new BookChapter(){Number=6,Title="6",Pages=6 },

            };

            books = new List<Book>() {

                new Book(1,"asp.net",chapters.ToArray()),
                new Book(2,"C#高级编程")

            };
        }

        // GET: api/BookChaptersArr
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BookChaptersArr/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BookChaptersArr
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BookChaptersArr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BookChaptersArr/5
        public void Delete(int id)
        {
        }

        /*Route特性中的bookid与动作方法参数名字要一致*/
        //[Route("{bookid:int}")]  需要配合前缀RoutePrefix属性
        //[Route("books/{bookid:int}")]
        //[Route("books/{bookid}/chapters/{chapterid}")]
        [Route("books/{bookid}")]
        public IEnumerable<BookChapter> GetBookChapters(int bookid)
        {
            return books.Where(book => book.id == bookid).SingleOrDefault().chapters;
        }
    }
}
