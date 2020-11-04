using Store;
using System;
using System.Linq;

namespace StoreMemory
{
    public class bookRepository : IBookRepository

    {
        private readonly Book[] books = new[]
        {
        new Book(1, "Art Of Programming", "ISBN 12345-54321","D. Knut", "Big book1", 7.19M),
        new Book(2, "All About Scram", "ISBN 11111-00000","M. Flauer", "Big book2", 79.19M),
        new Book(3, "C Programming language", "ISBN 12345-54322","L. Kerning", "Big book3", 57.19M)
        };

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query) 
                                    || book.Title.Contains(query))
                                       .ToArray();
        }
    }
}
