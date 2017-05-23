using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}