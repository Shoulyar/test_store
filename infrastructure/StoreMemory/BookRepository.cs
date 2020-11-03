using Store;
using System;
using System.Linq;

namespace StoreMemory
{
    public class bookRepository : IBookRepository

    {
        private readonly Book[] books = new[]
        {
        new Book(1, "Art Of Programming"),
        new Book(2, "All About Scram"),
        new Book(1, "C Programming language")
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
