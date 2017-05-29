using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Domain;
using Business.Repository;
using Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class BookEntity : IBookRepository
    {
        private DataContext db = new DataContext();

        public Book Create(string Isbn, string Title, int Year, ICollection<Author> Authors)
        {
            //Author author = db.Authors.Find(Authors);
            Book book = new Book();
            book.Isbn = Isbn;
            book.Title = Title;
            book.Year = Year;
            book.Authors.SelectMany(Author => Authors); //= author;
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public Book Delete(int? id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return new Book();
        }

        public Book Get(int? Id)
        {
            Book book = db.Books.Find(Id);
            return book;
        }

        public List<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public Book Update(int Id, string Isbn, string Title, int Year)
        {
            Book book = db.Books.Find(Id);
            if (book != null)
            {
                book.Title = (Title == null) ? book.Title : Title;
                book.Isbn = (Isbn == null) ? book.Isbn : Isbn;
                book.Year = (Year == null) ? book.Year : Year;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.Exist(Id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return book;
        }

        public bool Exist(int? id)
        {
           return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}