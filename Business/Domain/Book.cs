using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}