using Microsoft.EntityFrameworkCore;
using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Infrastructure.Data
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
    }
}
