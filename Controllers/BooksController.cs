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
        public JsonResult GetBooks(){
            return new JsonResult(BooksDataStore.Current.Books);
        }

        [HttpGet("{id}")]
        public JsonResult GetBook(int id){
            return new JsonResult(BooksDataStore.Current.Books.FirstOrDefault(c => c.Id == id ));
        }
    }
}