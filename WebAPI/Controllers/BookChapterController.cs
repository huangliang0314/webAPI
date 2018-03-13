using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BookChapterController : ApiController
    {
        public static List<BookChapter> chapters;

        static BookChapterController()
        {
            chapters = new List<BookChapter>() {
                new BookChapter(){Number=1,Title="1",Pages=1 },
                new BookChapter(){Number=2,Title="2",Pages=2 },
                new BookChapter(){Number=3,Title="3",Pages=3 },
                new BookChapter(){Number=4,Title="4",Pages=4 },
                new BookChapter(){Number=5,Title="5",Pages=5 },
                new BookChapter(){Number=6,Title="6",Pages=6 },

            };
        }

        // GET: api/BookChapter
        public IEnumerable<BookChapter> GetBookChapter()
        {
            return chapters;
        }

        // GET: api/BookChapter/5
        public BookChapter GetBookChapter(int id)
        {
            return chapters.Where(r => r.Number == id).SingleOrDefault();
        }

        // POST: api/BookChapter
        public void PostBookChapter([FromBody]BookChapter value)
        {
            chapters.Add(value);
        }

        // PUT: api/BookChapter/5
        public void PutBookChapter(int id, [FromBody]BookChapter value)
        {
            chapters.Remove(chapters.Where(r => r.Number == id).Single());
            chapters.Add(value);
        }

        // DELETE: api/BookChapter/5
        public void DeleteBookChapter(int id)
        {
            chapters.Remove(chapters.Where(r => r.Number == id).Single());
        }
    }
}
