using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myBookAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace myBookAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.OrderBy(c => c.Title).ToList();
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.Where(c => c.Id == bookId).FirstOrDefault();
        }
    }
}
