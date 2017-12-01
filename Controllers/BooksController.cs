using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace myBookAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        [HttpGet()]
        public JsonResult GetBooks(){
            return new JsonResult(BooksDataStore.Current.Books);
        }
    }
}