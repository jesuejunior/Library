﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Business.Domain;
using Data;
using Business.Repository;

namespace LibraryAPI.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IAuthorRepository service;
        //private Service.AuthorService service = new Service.AuthorService(new Data.AuthorEntity());
        public AuthorsController(IAuthorRepository _service)
        {
            service = _service;
        }

        // GET: api/Authors
        public List<Author> GetAuthors()
        {
            return service.GetAll();
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult GetAuthor(int id)
        {
            Author author = service.Get(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            service.Update(author.Id, author.FirstName, author.LastName, author.Email, author.Birthday);

            

            return Ok(author);
        }

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(author.FirstName, author.LastName, author.Email, author.Birthday);

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {
            Author author = service.Get(id);
            if (author == null)
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
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool AuthorExists(int id)
        {
            return service.Exist(id);
        }
    }
}