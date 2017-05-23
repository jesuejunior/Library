﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Domain;
using Business.Repository;
using Data;

namespace Data
{
    public class BookEntity : IBookRepository
    {
        private DataContext db = new DataContext();

        public Book Create(string Isbn, string Title, int Year)
        {
            Book book = new Book();
            book.Isbn = Isbn;
            book.Title = Title;
            book.Year = Year;
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public Book Delete(int? id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return book;
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
            throw new NotImplementedException();
        }
    }
}