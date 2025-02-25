
using Data.Contexts;
using Data.Repositories;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace WebApiServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            // Lägg till alla services här (inkl repositories, det är också en service). 
            // Se även till att DbContext har rätt connection string
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HBGROCA\Desktop\Github\EntityFrameWorkWithAPIExample\Data\Data\DataBaseLocal.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
            builder.Services.AddScoped<IGamesRepository, GamesRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Aktivera Scalar om nugget packet är installerat.
                // Denna kan du sen ansluta till via din webläsare.
                // https://localhost:7207/scalar/v1

                // Inne på sidan klickar du på önskad API metod 
                // och sen Test Request och sedan Send. Svaret
                // får du direkt efter i rutan till höger.

                app.MapScalarApiReference();


                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
