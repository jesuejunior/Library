using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Repository
{
    public interface IAuthorRepository
    {
        Author Create(string FirstName, string LastName, string Email, string Birthday);
        Author Update(int Id, string FirstName, string LastName, string Email, string Birthday);
        Author Get(int? Id);
        Author Delete(int? Id);
        List<Author> GetAll();
    }   
}