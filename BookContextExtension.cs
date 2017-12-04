using myBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBookAPI
{
    public static class BookContextExtensions
    {
        public static void EnsureSeedDataForContext(this BookContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            // init seed data
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Angular 2 rocks!",
                    Author = "John Doe",
                    Isbn = "1234567890",
                    Price = 5.89,
                    Rating = 3.5,
                    CoverUrl = "/assets/1.png"
                },
                new Book() 
                {   Id = 2,
                    Title = "Angular 4 rocks even more",
                    Author = "John Doe",
                    Isbn = "1234567891",
                    Price = 6.89,
                    Rating = 4.5,
                    CoverUrl = "/assets/2.png" 
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
