namespace myBookAPI.Models
{
    public class BookForCreationDto
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public string Isbn {get; set;}
        public double Price {get; set;}
        public double Rating {get; set;}
        public string CoverUrl {get; set;}
    }
}