using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;
using Owna.BookStore.Infrastructure.Data;

namespace Owna.BookStore.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(BookStoreDbContext context, ILogger<AuthorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Author?> GetAuthorByIdAsync(int id) => _context.Authors.FirstOrDefaultAsync(a => a.Id == id);

        public Task<List<Author>> GetAllAuthorsAsync() => _context.Authors.ToListAsync();

        public async Task AddAuthorAsync(Author author)
        {
            try
            {
                var added = await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully add author with {Name} and {Id} author to database", author.Name, added.Entity.Id);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Couldn't add {author} to {context}", author, _context.GetType());
                throw;
            }
        }
    }
}
