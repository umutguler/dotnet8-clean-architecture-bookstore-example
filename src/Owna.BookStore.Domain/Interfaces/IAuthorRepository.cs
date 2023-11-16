using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Author? GetAuthorById(int id);
        void AddAuthor(Author author);
        IEnumerable<Author> GetAllAuthors();
    }
}
