using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Repository;
using Business.Domain;

namespace Service
{
    public class BookService
    {
        private IBookRepository repository;

        public BookService(IBookRepository repository)
        {
            this.repository = repository;
        }
        public List<Book> GetAll()
        {
            return this.repository.GetAll();

        }

        public Book Create(string Isbn, string Title, int Year, ICollection<Author> Authors)
        {
            return this.repository.Create(Isbn, Title, Year, Authors);
        }

        public Book Get(int? id)
        {
            return this.repository.Get(id);
        }

        public Book Delete(int? id)
        {
            return this.repository.Delete(id);
        }

        public Book Update(int Id, string Isbn, string Title, int Year)
        {
            return this.repository.Update(Id, Isbn, Title, Year);
        }

        public bool Exist(int? id)
        {
            return this.repository.Exist(id);
        }
    }
}