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

        public void AddBook(Book book)
        {
            _context.Add(book);
        }

        public bool BookExists(int bookId)
        {
            return _context.Books.Any(c => c.Id == bookId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteBook(Book book)
        {
            _context.Remove(book);
        }


    }
}
