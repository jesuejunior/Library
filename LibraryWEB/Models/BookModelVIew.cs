using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWEB.Models
{
    public class BookModelView
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public BookModelView fromModel(Book model)
        {
            this.BookId = model.BookId;
            this.Isbn = model.Isbn;
            this.Title = model.Title;
            this.Authors = model.Authors;
            return this;

        }
    }
}