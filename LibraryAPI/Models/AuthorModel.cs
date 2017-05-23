using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }


}