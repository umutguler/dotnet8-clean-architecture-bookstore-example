namespace Owna.BookStore.Application.Dtos
{
    public class BookDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CoverImageUrl { get; set; } = default!;
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
    }
}
