using myBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBookAPI.Services
{
    public interface IBookRepository
    {
        // try the Get
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
    }
}
