using Owna.BookStore.Application.Dtos;

namespace Owna.BookStore.Application.Interfaces
{
    public interface IAuthorService
    {
        AuthorDto AddAuthor(AuthorDto authorDto);
        AuthorDto GetAuthorById(int id);
        IEnumerable<AuthorDto> GetAllAuthors();
    }
}
