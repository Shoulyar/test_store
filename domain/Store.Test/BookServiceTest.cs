using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Test
{
    public class BookServiceTest
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn() 
        {
            var bookRepositaryStub = new Mock<IBookRepository>();
            bookRepositaryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns (new[] { new Book(1, "", "","", "", 0m) });

            bookRepositaryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositaryStub.Object);

            var validIsbn = "ISBN 123-123-1234";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_GetAllByTitleOrAuthor()
        {
            var bookRepositaryStub = new Mock<IBookRepository>();
            bookRepositaryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositaryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositaryStub.Object);

            var invalidIsbn = "123-123-1234";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
