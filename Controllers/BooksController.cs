using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myBookAPI.Models;
using Microsoft.Extensions.Logging;
using myBookAPI.Services;
using AutoMapper;

namespace myBookAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet()]
        public IActionResult GetBooks()
        {
            var bookEntities = _bookRepository.GetBooks();
            return Ok(bookEntities);
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

            var finalBook = Mapper.Map<Entities.Book>(book);
            
            _bookRepository.AddBook(finalBook);
            if (!_bookRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdBookToReturn = Mapper.Map<Models.BookDto>(finalBook);
            return CreatedAtRoute("GetBookById", new{ id = finalBook.Id},createdBookToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,
            [FromBody] BookForUpdateDto book)
        {
            
            if (book == null){
                return BadRequest();
            }

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if (!_bookRepository.BookExists(id))
            {
                return NotFound();
            }
            
            var bookToUpdate = _bookRepository.GetBook(id);
            
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            
            //Mapper.Map(book,bookToUpdate);
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Isbn = book.Isbn;
            bookToUpdate.Price = book.Price;
            bookToUpdate.Rating = book.Rating;

            if (!_bookRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
            return NoContent();

        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateBook(int id,
            [FromBody] JsonPatchDocument <BookForUpdateDto> patchDoc)
        {
            
            if (patchDoc == null){
                return BadRequest();
            }

            var bookFromStore = BooksDataStore.Current.Books.FirstOrDefault(
                c => c.Id == id );

            if (bookFromStore == null)
            {
                return NotFound();
            }

            var bookForUpdateToPatch = new BookForUpdateDto()
            {
                Title = bookFromStore.Title,
                Author = bookFromStore.Author,
                Price = bookFromStore.Price,
                Rating = bookFromStore.Rating,
                Isbn = bookFromStore.Isbn,
                CoverUrl = bookFromStore.CoverUrl
            };
            patchDoc.ApplyTo(bookForUpdateToPatch);

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            TryValidateModel(bookForUpdateToPatch);
            
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            bookFromStore.Title = bookForUpdateToPatch.Title;
            bookFromStore.Author = bookForUpdateToPatch.Author;
            bookFromStore.Price = bookForUpdateToPatch.Price;
            bookFromStore.Rating = bookForUpdateToPatch.Rating;
            bookFromStore.Isbn = bookForUpdateToPatch.Isbn;
            bookFromStore.CoverUrl = bookForUpdateToPatch.CoverUrl;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            
            var bookToReturn = _bookRepository.GetBook(id);
            
            if (bookToReturn == null)
            {
                return NotFound();
            }
            
            _bookRepository.DeleteBook(bookToReturn);
            
            if (!_bookRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public IActionResult GetBook(int id){

            var bookToReturn = _bookRepository.GetBook(id);
            //BooksDataStore.Current.Books.FirstOrDefault(c => c.Id == id );
            
            if (bookToReturn == null)
            {
                return NotFound();
            }
            return Ok(bookToReturn);
        }

    }
}