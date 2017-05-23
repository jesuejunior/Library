using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWEB
{
    public class Factory
    {
        public static Service.BookService Book()
        {
            return new Service.BookService(new Data.BookEntity());    
        }

       
    }
}