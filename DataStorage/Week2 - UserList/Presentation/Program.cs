using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using Data.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\HBGROCA\\Desktop\\Github\\NET-WIN2024\\Datalagring\\Vecka 2\\Ovningsuppgift3\\Data\\Database\\ovningsuppgift3db.mdf\";Integrated Security=True;Connect Timeout=30"));
                services.AddSingleton<ICustomerServices, CustomerServices>();
                services.AddSingleton<ICustomerRepositories, CustomerRepositories>();
                services.AddSingleton<DataContext>();
                services.AddTransient<IDialogs, Dialogs>();
            }).Build();

            using var scope = host.Services.CreateScope();
            var mainMenu = scope.ServiceProvider.GetRequiredService<IDialogs>();

            while (true)
            {
                mainMenu.ShowMainDialog();
            }
        }
    }
}
