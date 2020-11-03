using System;

namespace Store
{
    public class Book
    {
        public int Id;
        public string Title { get;  }

        public Book(int id,string title) {
            Id = id;
            Title = title;
        }

    }
}
