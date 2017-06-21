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
    /// Descrição resumida para AuthorControllerTests
    /// </summary>
    [TestClass]
    public class AuthorControllerTests
    {
        public AuthorControllerTests()
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
        public void GetAllAuthorsTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();
            mockRepository.Setup(repository => repository.GetAll())
                .Returns(new List<Author>()
                {
                    new Author(){ Id = 1, FirstName = "joao", LastName = "Mighel", Email = "joao@gmail.com", Birthday = "22/12/1999" },
                    new Author(){ Id = 2, FirstName = "joao", LastName = "Mighel", Email = "joao@gmail.com", Birthday = "22/12/1999" }
                });
            var controller = new AuthorsController(mockRepository.Object);
            // Act
            var result = controller.GetAuthors();
            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetAuthorByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();
            mockRepository.Setup(repository => repository.Get(1))
                .Returns(
                    new Author() { Id = 1, FirstName = "joao", LastName = "Mighel", Email = "joao@gmail.com", Birthday = "22/12/1999" }
                );
            var controller = new AuthorsController(mockRepository.Object);
            // Act
            var result = controller.GetAuthor(1) as OkNegotiatedContentResult<Author>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void NotFoundGetAuthorByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();
            var controller = new AuthorsController(mockRepository.Object);
            // Act
            var result = controller.GetAuthor(10);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateAuthorTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();

            var controller = new AuthorsController(mockRepository.Object);
            var author = new Author() { Id = 1, FirstName = "joao", LastName = "Miguel", Email = "joao@gmail.com", Birthday = "22/12/1999" };
            // Act
            var result = controller.PutAuthor(1, author) as OkNegotiatedContentResult<Author>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
            Assert.AreEqual("Miguel", result.Content.LastName);
        }

        [TestMethod]
        public void CreateAuthorTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();

            var controller = new AuthorsController(mockRepository.Object);
            var author = new Author() { Id = 1, FirstName = "joao", LastName = "Miguel", Email = "joao@gmail.com", Birthday = "22/12/1999" };
            // Act
            var result = controller.PostAuthor(author) as CreatedAtRouteNegotiatedContentResult<Author>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void DeleteAuthorByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();
            mockRepository.Setup(repository => repository.Get(10))
                .Returns(
                    new Author() { Id = 10, FirstName = "joao", LastName = "Mighel", Email = "joao@gmail.com", Birthday = "22/12/1999" }
                );
            var controller = new AuthorsController(mockRepository.Object);
            // Act
            var result = controller.DeleteAuthor(10);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ExistAuthorByIdTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<IAuthorRepository>();
            mockRepository.Setup(repository => repository.Exist(10))
                .Returns(
                   true
                );
            var controller = new AuthorsController(mockRepository.Object);
            // Act
            var result = controller.AuthorExists(10);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
