using AutoMapper;
using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;

namespace Owna.BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.GetAuthorByIdAsync(id));
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task AddAuthor(AuthorDto authorDto)
        {
            await _authorRepository.AddAuthorAsync(_mapper.Map<Author>(authorDto));
        }
    }
}
