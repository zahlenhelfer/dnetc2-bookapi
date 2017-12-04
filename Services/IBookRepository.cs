using myBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBookAPI.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        bool BookExists(int bookId);
        void AddBook(Book book);
        bool Save();
        void DeleteBook(Book book);
    }
}
