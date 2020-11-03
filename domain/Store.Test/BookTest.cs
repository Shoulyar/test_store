using System;
using Xunit;

namespace Store.Test
{
    public class BookTest
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("    ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-12-33-444");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-12-33-444 236");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ghh IsBn 123-12-33-444 236 ghgh");

            Assert.False(actual);
        }
    }
}
