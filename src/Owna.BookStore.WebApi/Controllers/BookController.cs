using Microsoft.AspNetCore.Mvc;
using Owna.BookStore.Application.Dtos;
using Owna.BookStore.Application.Interfaces;

namespace Owna.BookStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is required.");
            }

            try
            {
                var createdBook = _bookService.AddBook(bookDto);
                return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the book.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("search")]
        public IActionResult SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query is required.");
            }

            var books = _bookService.SearchBooks(query);
            return Ok(books);
        }
    }
}