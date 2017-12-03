using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myBookAPI.Models;

namespace myBookAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        [HttpGet()]
        public IActionResult GetBooks()
        {
            return Ok(BooksDataStore.Current.Books);
        }

        [HttpPost()]
        public IActionResult CreateBook(
          [FromBody] BookForCreationDto book)
        {
            if (book == null){
                return BadRequest();
            }

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var books = BooksDataStore.Current.Books;

            // demo purposes - to be improved and needed to be changed
            var maxBookId = BooksDataStore.Current.Books.Max(c => c.Id);

            var finalBook = new BookDto()
            {
                Id = ++maxBookId,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                Price = book.Price,
                Rating = book.Rating,
                CoverUrl = book.CoverUrl
            };

            books.Add(finalBook);

            return CreatedAtRoute("GetBookById", new{ id = finalBook.Id},finalBook);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public IActionResult GetBook(int id){

            var bookToReturn = BooksDataStore.Current.Books.FirstOrDefault(c => c.Id == id );
            
            if (bookToReturn == null)
            {
                return NotFound();
            }
            return Ok(bookToReturn);
        }

    }
}