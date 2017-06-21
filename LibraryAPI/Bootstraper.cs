using Business.Repository;
using Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAPI
{
    public class Bootstraper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();
            container.RegisterType<IBookRepository, BookEntity>();
            container.RegisterType<IAuthorRepository, AuthorEntity>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}