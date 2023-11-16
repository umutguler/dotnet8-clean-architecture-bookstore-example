using Owna.BookStore.Domain.Data;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;

namespace Owna.BookStore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return _context.Books
                           .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            return _context.Books
                           .Where(b => b.Authors.Any(a => a.Name.Contains(authorName, StringComparison.OrdinalIgnoreCase)))
                           .ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
