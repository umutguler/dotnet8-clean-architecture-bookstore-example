
using Microsoft.EntityFrameworkCore;
using Owna.BookStore.Application.Mappers;
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
            builder.Logging.AddConsole();
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("BookStoreDb"));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            ServiceConfiguration.AddTransientServices(builder.Services);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedSampleDataFromJson.Seed(services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

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
