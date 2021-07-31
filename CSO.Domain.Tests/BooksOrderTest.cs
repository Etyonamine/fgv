
using CSO.Domain.Services;
using CSO.Domain.Entities;
using System.Collections.Generic;
using FluentAssertions;

using System.Linq;
using OrderService.Domain.Exceptions;
using NPOI.SS.Formula.Functions;
using Xunit;

namespace CSO.Domain.Tests
{
    public class BooksOrderTest
    {
        private readonly IBookOrderer _iBooksOrderer;

        public BooksOrderTest()
        {
            this._iBooksOrderer = new BookOrderer();
        }
        [Fact]
        public void Ordenacao_TituloAscendente()
        {
            int codigoConfiguracaoOrdem = 1;
            //Arrange
            List<Book> books = GetBooks();
            List<Book> booksExpected = books.OrderBy(a => a.Title).ToList();

            //Act
            var booksOrdered = _iBooksOrderer.Order(books, codigoConfiguracaoOrdem);

            //Assert
            object p = booksOrdered.Should().Equals(booksExpected);
        }

        [Fact]
        public void Ordenacao_AutorAscendente_TítuloDescendente()
        {
            int codigoConfiguracaoOrdem = 2;
            //Arrange
            List<Book> books = GetBooks();
            List<Book> booksExpected = books.OrderBy(a => a.Author).ThenByDescending(a => a.Title).ToList();

            //Act
            var booksOrdered = _iBooksOrderer.Order(books, codigoConfiguracaoOrdem);

            //Assert
            booksOrdered.Equals(booksExpected);
        }

        [Fact]
        public void Ordenacao_EdicaoDescendente_AutorDescendente_TituloAscendente()
        {
            int codigoConfiguracaoOrdem = 3;
            //Arrange
            List<Book> books = GetBooks();
            List<Book> booksExpected = books.OrderByDescending(a => a.Edition).ThenByDescending(a => a.Author).ThenBy(a => a.Title).ToList();

            //Act
            var booksOrdered = _iBooksOrderer.Order(books, codigoConfiguracaoOrdem);

            //Assert
            booksOrdered.Equals(booksExpected);
        }

        [Fact]
        public void Ordenacao_Nulo()
        {
            //Arrange
            List<Book> books = null;

            //Act
            void act() => _iBooksOrderer.Order(books, 1);

            //Assert
            var exception = Assert.Throws<OrderException>(act);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Equals("Coleção de livros nula", exception.Message);
        }

        [Fact]
        public void Ordenacao_ConjuntoVazio()
        {
            //Arrange
            var books = new List<Book>();

            //Act
            var booksOrdered = _iBooksOrderer.Order(books, 1);

            //Assert
            booksOrdered.Count.Equals(0);
        }
        #region Auxiliar

        public static List<Book> GetBooks()
        {
            //Livro 1     Java How to Program                                 Deitel & Deitel     2007
            //Livro 2     Patterns of Enterprise Application Architecture     Martin Fowler       2002
            //Livro 3     Head First Design Patterns                          Elisabeth Freeman   2004
            //Livro 4     Internet & World Wide Web: How to Program           Deitel & Deitel     2007

            return new List<Book>()
            {
                new Book( "Java How to Program", "Deitel & Deitel", 2007),
                new Book( "Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
                new Book( "Head First Design Patterns", "Elisabeth Freeman", 2004),
                new Book( "Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007)
            };


        }

        #endregion
    }
}
