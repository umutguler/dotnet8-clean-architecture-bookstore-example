namespace Owna.BookStore.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int BookId { get; set; }
        public Book Book { get; set; } = default!;
    }
}
