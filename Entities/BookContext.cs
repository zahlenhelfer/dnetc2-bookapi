using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace myBookAPI.Entities
{
    public class BookContext : DbContext
    {
 
        public BookContext(DbContextOptions<BookContext> options)
         : base(options)
        {
            Database.EnsureCreated(); 
        }

        public DbSet<Book> Books { get; set; }
    }

}
