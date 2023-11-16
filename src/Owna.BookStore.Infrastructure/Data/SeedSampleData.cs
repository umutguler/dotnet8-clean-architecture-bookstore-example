using Microsoft.EntityFrameworkCore;
using Owna.BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owna.BookStore.Infrastructure.Data
{
    public static class SeedSampleData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "F. Scott Fitzgerald" },
                new Author { Id = 2, Name = "Harper Lee" },
                new Author { Id = 3, Name = "George Orwell" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Description = "The story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.",
                    CoverImageUrl = "https://example.com/gatsby.jpg",
                    Authors = new List<Author> { new Author { Id = 1 } }
                }
            );
        }
    }
}
