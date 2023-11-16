using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Application.Services;
using Owna.BookStore.Domain.Interfaces;
using Owna.BookStore.Infrastructure;

namespace Owna.BookStore.WebApi.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddTransientServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
        }
    }
}
