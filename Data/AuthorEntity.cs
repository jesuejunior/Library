using Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Domain;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class AuthorEntity : IAuthorRepository
    {
        private DataContext db = new DataContext();
        public Author Create(string FirstName, string LastName, string Email, string Birthday)
        {
            Author author = new Author();
            author.FirstName = FirstName;
            author.LastName = LastName;
            author.Email = Email;
            author.Birthday = Birthday;
            db.Authors.Add(author);
            db.SaveChanges();
            return author;
        }

        public Author Delete(int? Id)
        {
            Author author = db.Authors.Find(Id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return new Author();
        }

        public Author Get(int? Id)
        {
            Author author = db.Authors.Find(Id);
            return author;
        }

        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public Author Update(int Id, string FirstName, string LastName, string Email, string Birthday)
        {
            Author author = db.Authors.Find(Id);
            if(author != null)
            {
                author.FirstName = (FirstName == null) ? author.FirstName : FirstName;
                author.LastName = (LastName == null) ? author.LastName : LastName;
                author.Email = (Email == null) ? author.Email : Email;
                author.Birthday = (Birthday == null) ? author.Birthday : Birthday;

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
            return author;
        }

        public bool Exist(int? id)
        {
            return db.Authors.Count(e => e.Id == id) > 0;
        }
    }
}