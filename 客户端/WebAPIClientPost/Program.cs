using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using System.Net.Http;
using System.Net.Http.Formatting;



namespace WebAPIClientPost
{
    class Program
    {
        static void Main(string[] args)
        {

            addSample().Wait();
            Console.ReadLine();

        }

        private static async Task addSample()
        {
            BookChapter chapter = new BookChapter()
            {
                Number = 7,
                Pages=7,
                Title="7"
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50626");

            HttpResponseMessage response=   await client.PostAsync<BookChapter>("/api/BookChapter", chapter,new JsonMediaTypeFormatter());
            Console.WriteLine(await response.Content.ReadAsAsync(chapter.GetType()));
            
        }
    }
}
