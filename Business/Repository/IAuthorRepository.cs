using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Repository
{
    public interface IAuthorRepository
    {
        Author create(int AuthorId, string FirstName, string LastName);
    }
}