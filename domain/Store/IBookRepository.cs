using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book GetById(int id);
        Book[] GetAllByIsbn(string isbn);
        Book[] GetAllByTitleOrAuthor(string titlePartOrAuthor);
    }
}
