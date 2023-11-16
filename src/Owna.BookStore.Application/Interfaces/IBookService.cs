using Owna.BookStore.Application.Dtos;

namespace Owna.BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> SearchBooksAsync(string query);
        Task AddBookAsync(BookDto bookDto);
    }
}
