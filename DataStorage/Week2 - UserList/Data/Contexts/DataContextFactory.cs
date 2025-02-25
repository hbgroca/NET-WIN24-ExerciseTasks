using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\HBGROCA\\Desktop\\Github\\NET-WIN2024\\Datalagring\\Vecka 2\\Ovningsuppgift3\\Data\\Database\\ovningsuppgift3db.mdf\";Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }
}