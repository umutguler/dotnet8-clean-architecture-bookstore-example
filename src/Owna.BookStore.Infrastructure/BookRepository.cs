using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;
using Owna.BookStore.Infrastructure.Data;

namespace Owna.BookStore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(BookStoreDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            return _context.Books
                           .Include(b => b.Authors)
                           .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string title)
        {
            return await _context.Books
                           .Include(b => b.Authors)
                           .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                           .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string authorName)
        {
            return await _context.Books
                           .Include(b => b.Authors)
                           .Where(b => b.Authors.Any(a => a.Name.Contains(authorName, StringComparison.OrdinalIgnoreCase)))
                           .ToListAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            try
            {
                var added = await _context.Books.AddAsync(book);
                await _context.AddRangeAsync(book.Authors);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully add author with {Title} and {Id} author to database", book.Title, added.Entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Couldn't add {book} to {context}", book, _context.GetType());
                throw;
            }
        }
    }
}
