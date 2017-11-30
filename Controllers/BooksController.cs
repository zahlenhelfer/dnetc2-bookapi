namespace myBookAPI.Controllers
{
    public class BooksController : Controller
    {
        public JsonResult GetBooks(){
            return new JsonResult(new List<object>(){
                new { title = "Angular 4 rocks even more",
                      author = "John Doe",
                      isbn = "1234567891",
                      price = 6.89,
                      rating = 4.5,
                      coverUrl = "/assets/2.png" },
                new { title = "Angular 2 rocks!",
                      author = "John Doe",
                      isbn = "1234567890",
                      price = 5.89,
                      rating = 3.5,
                      coverUrl = "/assets/1.png"}
            });
    }
}