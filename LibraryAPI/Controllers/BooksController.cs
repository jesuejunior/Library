using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Business.Domain;
using Data;
using Service;
using Business.Repository;

namespace LibraryAPI.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository service;
        //private Service.BookService service = new Service.BookService(new Data.BookEntity());
        //private BookService service;

        //public BooksController() :
        //    this(new BookService(new Data.BookEntity()))
        //{ }
        public BooksController(IBookRepository _service) {
            service = _service;
        }

        // GET: api/Books
        public List<Book> GetBooks()
        {
            return service.GetAll();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = service.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            service.Update(book.Id, book.Isbn, book.Title, book.Year);

            return Ok(book);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)

            {
                return BadRequest(ModelState);
            }

            service.Create(book.Isbn, book.Title, book.Year, book.Authors);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = service.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            service.Delete(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool BookExists(int id)
        {
            return service.Exist(id);
        }
    }
}