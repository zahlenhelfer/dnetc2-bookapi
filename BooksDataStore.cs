using myBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBookAPI
{
    public class BooksDataStore
    {
        public static BooksDataStore Current {get;} = new BooksDataStore();

        public List<BookDto> Books {get; set;}

        public BooksDataStore()
        {
            //init dummy data
            Books = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = 1,
                    Title = "Angular 2 rocks!",
                    Author = "John Doe",
                    Isbn = "1234567890",
                    Price = 5.89,
                    Rating = 3.5,
                    CoverUrl = "/assets/1.png"
                },
                new BookDto() 
                {   Id = 2,
                    Title = "Angular 4 rocks even more",
                    Author = "John Doe",
                    Isbn = "1234567891",
                    Price = 6.89,
                    Rating = 4.5,
                    CoverUrl = "/assets/2.png" 
                }
            };
        }
    }
}