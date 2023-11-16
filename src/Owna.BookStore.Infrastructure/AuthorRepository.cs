using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;
using Owna.BookStore.Infrastructure.Data;

namespace Owna.BookStore.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public Author? GetAuthorById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

        public IEnumerable<Author> GetAllAuthors() => _context.Authors.ToList();

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}
