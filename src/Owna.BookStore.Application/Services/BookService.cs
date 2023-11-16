using AutoMapper;
using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;

namespace Owna.BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            return _mapper.Map<BookDto>(await _bookRepository.GetBookByIdAsync(id));
        }

        public async Task<IEnumerable<BookDto>> SearchBooksAsync(string query)
        {
            var books = (await _bookRepository.GetBooksByTitleAsync(query))
                        .Concat(await _bookRepository.GetBooksByAuthorAsync(query))
                        .Distinct();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddBookAsync(book);
        }
    }
}
