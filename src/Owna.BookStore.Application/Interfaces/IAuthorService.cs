using Owna.BookStore.Application.Dtos;

namespace Owna.BookStore.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAuthorById(int id);
        Task<IEnumerable<AuthorDto>> GetAllAuthors();
        Task AddAuthor(AuthorDto authorDto);
    }
}
