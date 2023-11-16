namespace Owna.BookStore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CoverImageUrl { get; set; } = default!;
        public List<Author> Authors { get; set; } = new List<Author>();

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }
    }

}
