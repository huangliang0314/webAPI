using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace WebAPIServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new HttpSelfHostConfiguration("http://localhost:8081");
            config.MapHttpAttributeRoutes();
            using (var server =new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("服务已启动...");
                Console.ReadLine();
            }
        }
    }

    [RoutePrefix("Books")]
    public class BookController : ApiController
    {
        [Route("TheOne")]
        public IEnumerable<Book> GetBooks()
        {

            return new List<Book>()
            {
                    new Book(1,"gaojibianc"),
                    new Book(id:2,title:"噶系边吃")
            };
        }


    }
}
