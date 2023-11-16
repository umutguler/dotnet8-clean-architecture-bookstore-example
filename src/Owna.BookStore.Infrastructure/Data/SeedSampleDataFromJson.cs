using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Owna.BookStore.Domain.Entities;
using System.Text.Json;

namespace Owna.BookStore.Infrastructure.Data
{
    public static class SeedSampleDataFromJson
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Authors.Any() || context.Books.Any())
                {
                    return; // Data already seeded
                }

                string booksJson = File.ReadAllText("Data/book_seed.json");
                string authorsJson = File.ReadAllText("Data/author_seed.json");
                List<Book> books = JsonSerializer.Deserialize<List<Book>>(booksJson);
                List<Author> authors = JsonSerializer.Deserialize<List<Author>>(authorsJson);

                if (books != null)
                    context.Books.AddRange(books);

                if (authors != null)
                    context.Authors.AddRange(authors);

                context.SaveChanges();
            }
        }
    }
}
