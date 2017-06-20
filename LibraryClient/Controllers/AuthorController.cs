using Business.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryClient.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        string Baseurl = "http://127.0.0.1:50102/";
        public async Task<ActionResult> Index()
        {
            List<Author> AuthorInfo = new List<Author>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Authors");
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<List<Author>>(AuthorResponse);
                }
                return View(AuthorInfo);
            }
        }



        public async Task<ActionResult> Details(int? id)
        {
            Author AuthorInfo = new Author();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Authors/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                }
                return View(AuthorInfo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,Birthday")] Author author)
        {
            Author AuthorInfo = new Author();
            var AuthorJson = JsonConvert.SerializeObject(author);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Authors", AuthorJson);
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                }
                return View(author);
            }

        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author AuthorInfo = new Author();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Authors/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                }
                return View(AuthorInfo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Email,Birthday")] Author author)
        {
            if (ModelState.IsValid)
            {
                Author AuthorInfo = new Author();
                var AuthorJson = JsonConvert.SerializeObject(author);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PutAsJsonAsync("api/Authors", AuthorJson);
                    if (Res.IsSuccessStatusCode)
                    {
                        var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                        AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author AuthorInfo = new Author();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/Authors/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                }
                return View(AuthorInfo);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Author AuthorInfo = new Author();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync($"api/Authors/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var AuthorResponse = Res.Content.ReadAsStringAsync().Result;
                    AuthorInfo = JsonConvert.DeserializeObject<Author>(AuthorResponse);
                }
                return RedirectToAction("Index");

            }

        }

    }
}