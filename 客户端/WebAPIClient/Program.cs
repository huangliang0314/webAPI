using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using WebAPI.Models;


namespace WebAPIClientGET
{
    class Program
    {
        static void Main(string[] args)
        {
            /*①*****************************
            *                               *
            *     返回JSON                  *
            *  ReadArrSampleJson().Wait();  * 
            *                               *
            *                               * 
            *                               */

            /*②*****************************
            *                               *
            *     返回XMl                   *
            *  ReadArrSampleXML().Wait();   * 
            *                               *
            *                               * 
            *                               */

            /*③*****************************
            *                               *
            *     扩展                      *
            *  ReadArrSampleExtention().Wait();* 
            *                               *
            *                               * 
            *                               */
            ReadArrSampleExtention().Wait();
            Console.ReadLine();
        }

        public static async Task ReadArrSampleJson()
        {
            HttpClient lClient = new HttpClient();
            lClient.BaseAddress = new Uri("http://localhost:50626");
            string response = await lClient.GetStringAsync("/api/BookChapter");
            Console.WriteLine(response);
            JavaScriptSerializer jsSeria = new JavaScriptSerializer();
            BookChapter[] chapters = jsSeria.Deserialize<BookChapter[]>(response);
            foreach (var chapter in chapters)
            {
                Console.WriteLine(chapter.Title);
            }
        }

        public static async Task ReadArrSampleXML()
        {
            HttpClient lClient = new HttpClient();
            lClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
            lClient.BaseAddress = new Uri("http://localhost:50626");
            string response = await lClient.GetStringAsync("/api/BookChapter");
            Console.WriteLine(response);
            XElement xe = XElement.Parse(response,LoadOptions.SetLineInfo);
            
            Console.WriteLine(xe);
        }

        public static async Task ReadArrSampleExtention()
        {
            HttpClient lClient = new HttpClient();
            lClient.BaseAddress = new Uri("http://localhost:50626");

            HttpResponseMessage httpRes = await lClient.GetAsync("/api/BookChapter");
           
            Console.WriteLine(httpRes.Content);

            BookChapter[] chapters =await httpRes.Content.ReadAsAsync<BookChapter[]>();
            foreach (var chapter in chapters)
            {
                Console.WriteLine(chapter.Title);
            }
        }

    }
}
