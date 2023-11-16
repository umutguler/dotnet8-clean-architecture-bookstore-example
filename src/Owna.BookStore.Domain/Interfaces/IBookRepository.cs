using Owna.BookStore.Domain.Entities;

namespace Owna.BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetBooksByTitle(string title);
        IEnumerable<Book> GetBooksByAuthor(string authorName);
        Book? GetBookById(int id);
    }

}
