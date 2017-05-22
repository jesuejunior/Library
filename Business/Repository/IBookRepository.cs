using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Repository
{
    public interface IBookRepository
    {
        Book create(int BookId, string Isbn, string Title);
    }
}