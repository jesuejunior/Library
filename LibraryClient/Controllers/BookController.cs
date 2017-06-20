using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Business.Domain;
using System.Net;

namespace LibraryClient.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        string Baseurl = "http://127.0.0.1:50102/";
        public async Task<ActionResult> Index()
        {
            List<Book> BookInfo = new List<Book>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Books");
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<List<Book>>(BookResponse);
                }
                return View(BookInfo);
            }
        }

        public async Task<ActionResult> Details(int? id)
        {
            Book BookInfo = new Book();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Books/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                }
                return View(BookInfo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Isbn,Title,Year,Authors")] Book book)
        {
            Book BookInfo = new Book();
            var BookJson = JsonConvert.SerializeObject(book);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Books", BookJson );
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                }
                return View(book);
            }

        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book BookInfo = new Book();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Books/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                }
                return View(BookInfo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Isbn,Title,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                Book BookInfo = new Book();
                var BookJson = JsonConvert.SerializeObject(book);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PutAsJsonAsync("api/Books", BookJson );
                    if (Res.IsSuccessStatusCode)
                    {
                        var BookResponse = Res.Content.ReadAsStringAsync().Result;
                        BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book BookInfo = new Book();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Books/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                }
                return View(BookInfo);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Book BookInfo = new Book();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync($"api/Books/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var BookResponse = Res.Content.ReadAsStringAsync().Result;
                    BookInfo = JsonConvert.DeserializeObject<Book>(BookResponse);
                }
                return RedirectToAction("Index");

            }

        }
    }
}