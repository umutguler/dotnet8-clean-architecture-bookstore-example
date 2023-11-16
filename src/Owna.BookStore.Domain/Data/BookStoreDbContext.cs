using Microsoft.EntityFrameworkCore;
using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Domain.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
