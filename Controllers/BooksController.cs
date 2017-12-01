using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("{id}")]
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