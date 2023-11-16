using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<List<Author>> GetAllAuthorsAsync();
        Task AddAuthorAsync(Author author);
    }
}
