using Microsoft.AspNetCore.Mvc;
using myBookAPI.Entities;

namespace myBookAPI.Controllers
{
    public class DummyController : Controller
    {
        private BookContext _ctx;

        public DummyController(BookContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
