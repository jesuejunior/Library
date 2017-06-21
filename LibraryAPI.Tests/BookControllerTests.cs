using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Repository;
using Moq;
using Business.Domain;
using LibraryAPI.Controllers;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Net;

namespace LibraryAPI.Tests
{
    /// <summary>
    /// Descrição resumida para BookControllerTests
    /// </summary>
    [TestClass]
    public class BookControllerTests
    {
        public BookControllerTests()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllBooksTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            mockRepository.Setup(repository => repository.GetAll())
                .Returns(new List<Book>()
                {
                    new Book(){ Id = 1, Isbn = "1234567", Title = "teste1", Year = 2016},
                    new Book(){ Id = 2, Isbn = "12345678", Title = "teste2", Year = 2017}
                });
            var controller = new BooksController(mockRepository.Object);
            // Act
            var result = controller.GetBooks();
            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetBookByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            mockRepository.Setup(repository => repository.Get(1))
                .Returns(
                    new Book(){ Id = 1, Isbn = "1234567", Title = "teste1", Year = 2016}
                );
            var controller = new BooksController(mockRepository.Object);
            // Act
            var result = controller.GetBook(1) as OkNegotiatedContentResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void NotFoundGetBookByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            var controller = new BooksController(mockRepository.Object);
            // Act
            var result = controller.GetBook(10);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateBookTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();

            var controller = new BooksController(mockRepository.Object);
            var book = new Book() { Id = 1, Isbn = "1234568", Title = "testeOK", Year = 2012 };
            // Act
            var result = controller.PutBook(1, book) as OkNegotiatedContentResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
            Assert.AreEqual(2012, result.Content.Year);
        }

        [TestMethod]
        public void CreateBookTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();

            var controller = new BooksController(mockRepository.Object);
            var book = new Book() { Id = 1, Isbn = "1234568", Title = "testeOK", Year = 2012 };
            // Act
            var result = controller.PostBook( book) as CreatedAtRouteNegotiatedContentResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void DeleteBookByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            mockRepository.Setup(repository => repository.Get(10))
                .Returns(
                    new Book() { Id = 10, Isbn = "1234567", Title = "teste1", Year = 2016 }
                );
            var controller = new BooksController(mockRepository.Object);
            // Act
            var result = controller.DeleteBook(10);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ExistBookByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            mockRepository.Setup(repository => repository.Exist(10))
                .Returns(
                   true
                );
            var controller = new BooksController(mockRepository.Object);
            // Act
            var result = controller.BookExists(10);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
