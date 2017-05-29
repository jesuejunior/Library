using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Repository;
using Business.Domain;

namespace Service
{
    public class AuthorService
    {
        private IAuthorRepository repository;

        public AuthorService(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        public List<Author> GetAll()
        {
            return this.repository.GetAll();
        }

        public Author Create(string FirstName, string LastName, string Email, string Birthday)
        {
            return this.repository.Create(FirstName, LastName, Email, Birthday);
        }

        public Author Get(int? id)
        {
            return this.repository.Get(id);
        }

        public Author Delete(int? id)
        {
            return this.repository.Delete(id);
        }

        public Author Update(int Id, string FirstName, string LastName, string Email, string Birthday)
        {
            return this.repository.Update(Id, FirstName, LastName, Email, Birthday);
        }

        public bool Exist(int? id)
        {
            return this.repository.Exist(id);
        }
    }
}