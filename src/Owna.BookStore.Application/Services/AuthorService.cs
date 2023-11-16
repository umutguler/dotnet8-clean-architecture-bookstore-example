using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;

namespace Owna.BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public AuthorDto GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name
            };

            _authorRepository.AddAuthor(author);
            authorDto.Id = author.Id;
            return authorDto;
        }
    }
}
