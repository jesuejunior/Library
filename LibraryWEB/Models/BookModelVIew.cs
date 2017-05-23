using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWEB.Models
{
    public class BookModelView
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public BookModelView fromModel(Book model)
        {
            this.Id = model.Id;
            this.Isbn = model.Isbn;
            this.Title = model.Title;
            this.Year = model.Year;
            this.Authors = model.Authors;
            return this;

        }
    }
}