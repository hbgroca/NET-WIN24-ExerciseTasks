using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class GamesRepository(DataContext _context) : IGamesRepository
{
    public async Task<IEnumerable<GameEntity>> GetAllGamesAsync()
    {
        // När vi hämtar upp spelen så meddelar vi att vi även till inkludera
        // Details, Genres och Developer som är kopplat.
        var games = await _context.Games
            .Include(g => g.Details)
            .Include(g => g.Genres)
            .Include(g => g.Developer)
            .ToListAsync();

        // Returera listan med spel eller en tom lista om games är null.
        return games ?? [];
    }

    public async Task<GameEntity> GetGameByIdAsync(int id)
    {
        var game = await _context.Games
            .Include(g => g.Details)
            .Include(g => g.Genres)
            .Include(g => g.Developer)
            .FirstOrDefaultAsync(g => g.Id == id);

        return game ?? null!;
    }

    public async Task<GameEntity> GetGameByTitleAsync(string title)
    {
        var game = await _context.Games
            .Include(g => g.Details)
            .Include(g => g.Genres)
            .Include(g => g.Developer)
            .FirstOrDefaultAsync(g => g.Title == title);

        return game ?? null!;
    }
}
