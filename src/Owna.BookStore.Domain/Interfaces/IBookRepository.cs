using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksByTitleAsync(string title);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string authorName);
        Task AddBookAsync(Book book);
    }

}
