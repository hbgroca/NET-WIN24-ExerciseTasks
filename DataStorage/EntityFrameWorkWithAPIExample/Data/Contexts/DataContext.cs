using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        // Här specificerar du alla! entities. Du måste inte lägga till detta men annars väljer
        // entity framework namnet själv och det kan bli lite svårt att förstå sen i databasen.
        // Namnet du väljer är det namn som skapas i din databas.
        // Det blir även din sökväg för att komma åt datan sen. Ex "await _context.Games.AddAsync();"
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<DeveloperEntity> Developers => Set<DeveloperEntity>();
        public DbSet<GenreEntity> Genres => Set<GenreEntity>();
        public DbSet<GameDetails> GameDetails => Set<GameDetails>();


        // Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //// In Memory cache, to increase performance (Works best in local DB)
            optionsBuilder.EnableServiceProviderCaching();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Lägger till data vid skapande av database
            modelBuilder.Entity<DeveloperEntity>().HasData(
                new DeveloperEntity
                {
                    Id = 1,
                    Name = "Blizzard Entertainment",
                    Description = "Blizzard Entertainment, Inc. is an American video game developer and publisher based in Irvine, California.",
                    StartedDate = DateOnly.Parse("1991-02-01"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 2,
                    Name = "Valve Corporation",
                    Description = "Valve Corporation is an American video game developer, publisher, and digital distribution company headquartered in Bellevue, Washington.",
                    StartedDate = DateOnly.Parse("1996-08-24"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 3,
                    Name = "Rockstar Games",
                    Description = "Rockstar Games, Inc. is an American video game publisher based in New York City.",
                    StartedDate = DateOnly.Parse("1998-12-01"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 4,
                    Name = "Electronic Arts",
                    Description = "Electronic Arts Inc. is an American video game company headquartered in Redwood City, California.",
                    StartedDate = DateOnly.Parse("1982-05-28"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 5,
                    Name = "Ubisoft",
                    Description = "Ubisoft Entertainment SA is a French video game company headquartered in Montreuil with several development studios across the world.",
                    StartedDate = DateOnly.Parse("1986-03-12"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 6,
                    Name = "Square Enix",
                    Description = "Square Enix Holdings Co., Ltd. is a Japanese video game developer, publisher, and distribution company known for its Final Fantasy, Dragon Quest, and Kingdom Hearts role-playing video game franchises.",
                    StartedDate = DateOnly.Parse("2003-04-01"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 7,
                    Name = "Capcom",
                    Description = "Capcom Co., Ltd. is a Japanese video game developer and publisher known for creating multi-million-selling franchises such as Resident Evil, Street Fighter, and Monster Hunter.",
                    StartedDate = DateOnly.Parse("1979-05-30"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 8,
                    Name = "Naughty Dog",
                    Description = "Naughty Dog, LLC is an American first-party video game developer based in Santa Monica, California.",
                    StartedDate = DateOnly.Parse("1984-09-27"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 9,
                    Name = "Bungie",
                    Description = "Bungie, Inc. is an American video game developer based in Bellevue, Washington.",
                    StartedDate = DateOnly.Parse("1991-05-01"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 10,
                    Name = "CD Projekt Red",
                    Description = "CD Projekt Red is a Polish video game developer based in Warsaw, founded in 2002.",
                    StartedDate = DateOnly.Parse("2002-02-01"),
                    EndedDate = null,
                },
                new DeveloperEntity
                {
                    Id = 11,
                    Name = "Bethesda Game Studios",
                    Description = "Bethesda Game Studios is an American video game developer and a studio of ZeniMax Media based in Rockville, Maryland.",
                    StartedDate = DateOnly.Parse("2001-10-01"),
                    EndedDate = null,
                }
            );

            modelBuilder.Entity<GenreEntity>().HasData(
                new GenreEntity
                {
                    Id = 1,
                    Genre = "FPS",
                },
                new GenreEntity
                {
                    Id = 2,
                    Genre = "RPG",
                },
                new GenreEntity
                {
                    Id = 3,
                    Genre = "Action",
                },
                new GenreEntity
                {
                    Id = 4,
                    Genre = "Adventure",
                },
                new GenreEntity
                {
                    Id = 5,
                    Genre = "Strategy",
                },
                new GenreEntity
                {
                    Id = 6,
                    Genre = "Simulation",
                }
            );

            modelBuilder.Entity<GameDetails>().HasData(
                new GameDetails
                {
                    Id = 1,
                    Description = "Diablo 2: Lord Of Destruction",
                    GameEntityId = 1,
                    ReleaseDate = DateOnly.Parse("2000-06-30"),
                },
                new GameDetails
                {
                    Id = 2,
                    Description = "Half-Life 2",
                    GameEntityId = 2,
                    ReleaseDate = DateOnly.Parse("2004-11-16"),
                },
                new GameDetails
                {
                    Id = 3,
                    Description = "Grand Theft Auto V",
                    GameEntityId = 3,
                    ReleaseDate = DateOnly.Parse("2013-09-17"),
                },
                new GameDetails
                {
                    Id = 4,
                    Description = "The Sims 4",
                    GameEntityId = 4,
                    ReleaseDate = DateOnly.Parse("2014-09-02"),
                },
                new GameDetails
                {
                    Id = 5,
                    Description = "Assassin's Creed Valhalla",
                    GameEntityId = 5,
                    ReleaseDate = DateOnly.Parse("2020-11-10"),
                },
                new GameDetails
                {
                    Id = 6,
                    Description = "Final Fantasy XV",
                    GameEntityId = 6,
                    ReleaseDate = DateOnly.Parse("2016-11-29"),
                },
                new GameDetails
                {
                    Id = 7,
                    Description = "Resident Evil Village",
                    GameEntityId = 7,
                    ReleaseDate = DateOnly.Parse("2021-05-07"),
                },
                new GameDetails
                {
                    Id = 8,
                    Description = "The Last of Us Part II",
                    GameEntityId = 8,
                    ReleaseDate = DateOnly.Parse("2020-06-19"),
                },
                new GameDetails
                {
                    Id = 9,
                    Description = "Destiny 2",
                    GameEntityId = 9,
                    ReleaseDate = DateOnly.Parse("2017-09-06"),
                },
                new GameDetails
                {
                    Id = 10,
                    Description = "Cyberpunk 2077",
                    GameEntityId = 10,
                    ReleaseDate = DateOnly.Parse("2020-12-10"),
                }
            );
            
            modelBuilder.Entity<GameEntity>().HasData(
                new GameEntity
                {
                    Id = 1,
                    Title = "Diablo 2: Lord Of Destruction",
                    DeveloperId = 1,
                },
                new GameEntity
                {
                    Id = 2,
                    Title = "Half-Life 2",
                    DeveloperId = 2,
                },
                new GameEntity
                {
                    Id = 3,
                    Title = "Grand Theft Auto V",
                    DeveloperId = 3,
                },
                new GameEntity
                {
                    Id = 4,
                    Title = "The Sims 4",
                    DeveloperId = 4,
                },
                new GameEntity
                {
                    Id = 5,
                    Title = "Assassin's Creed Valhalla",
                    DeveloperId = 5,
                },
                new GameEntity
                {
                    Id = 6,
                    Title = "Final Fantasy XV",
                    DeveloperId = 6,
                },
                new GameEntity
                {
                    Id = 7,
                    Title = "Resident Evil Village",
                    DeveloperId = 7,
                },
                new GameEntity
                {
                    Id = 8,
                    Title = "The Last of Us Part II",
                    DeveloperId = 8,
                },
                new GameEntity
                {
                    Id = 9,
                    Title = "Destiny 2",
                    DeveloperId = 9,
                },
                new GameEntity
                {
                    Id = 10,
                    Title = "Cyberpunk 2077",
                    DeveloperId = 10,
                }
            );

        }
    }
}
