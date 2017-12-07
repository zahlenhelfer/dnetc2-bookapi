using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace myBookAPI.Entities
{
    public class BookContext : DbContext
    {
 
        public BookContext(DbContextOptions<BookContext> options)
         : base(options)
        {
            Database.Migrate(); 
        }

        public DbSet<Book> Books { get; set; }
    }

}
