
using Microsoft.EntityFrameworkCore;
using Owna.BookStore.Application.Interfaces;
using Owna.BookStore.Application.Services;
using Owna.BookStore.Domain.Interfaces;
using Owna.BookStore.Infrastructure;
using Owna.BookStore.Infrastructure.Data;
using Owna.BookStore.WebApi.Configuration;

namespace Owna.BookStore.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("BookStoreDb"));
            ServiceConfiguration.AddTransientServices(builder.Services);

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
