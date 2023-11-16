using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Domain.Entities;
using Owna.BookStore.Domain.Interfaces;

namespace Owna.BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public BookDto GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            var bookDto = new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                CoverImageUrl = book.CoverImageUrl,
                Authors = null
            };

            return bookDto;
        }

        public BookDto AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                CoverImageUrl = bookDto.CoverImageUrl
            };

            foreach (var authorDto in bookDto.Authors)
            {
                var author = _authorRepository.GetAuthorById(authorDto.Id);
                if (author != null)
                {
                    book.AddAuthor(author);
                }
            }

            _bookRepository.AddBook(book);
            bookDto.Id = book.Id;
            return bookDto;
        }

        public IEnumerable<BookDto> SearchBooks(string query)
        {
            var books = _bookRepository.GetBooksByTitle(query)
                .Concat(_bookRepository.GetBooksByAuthor(query))
                .Distinct();

            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                CoverImageUrl = book.CoverImageUrl,
                Authors = book.Authors.Select(author => new AuthorDto
                {
                    Id = author.Id,
                    Name = author.Name
                }).ToList()
            });
        }
    }
}
