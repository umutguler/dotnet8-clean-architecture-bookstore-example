using Owna.BookStore.Application.Dtos;

namespace Owna.BookStore.Application.Interfaces
{
    public interface IBookService
    {
        BookDto AddBook(BookDto bookDto);
        IEnumerable<BookDto> SearchBooks(string query);
        BookDto GetBookById(int id);
    }
}
