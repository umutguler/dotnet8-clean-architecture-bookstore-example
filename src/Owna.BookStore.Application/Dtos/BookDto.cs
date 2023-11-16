namespace Owna.BookStore.Application.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CoverImageUrl { get; set; } = default!;
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
    }
}
